using Microsoft.EntityFrameworkCore;
using WebAspApp.Data;
using WebAspApp.Repositories;
using WebAspApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Základní services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Connection string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
}

Console.WriteLine($"Using connection string: {connectionString}");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(connectionString);

    if (builder.Environment.IsDevelopment())
    {
        options.LogTo(Console.WriteLine, LogLevel.Information)
               .EnableSensitiveDataLogging()
               .EnableDetailedErrors();
    }
});

builder.Services.AddHealthChecks();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapHealthChecks("/health");
app.MapControllers();

try
{
    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

    var canConnect = await context.Database.CanConnectAsync();
    Console.WriteLine($"✅ Database connection test: {(canConnect ? "SUCCESS" : "FAILED")}");

    if (canConnect)
    {
        var pendingMigrations = await context.Database.GetPendingMigrationsAsync();
        if (pendingMigrations.Any())
        {
            Console.WriteLine("📦 Applying pending migrations...");
            await context.Database.MigrateAsync();
            Console.WriteLine("✅ Migrations applied successfully!");
        }
        else
        {
            Console.WriteLine("✅ Database is up to date!");
        }
    }
}
catch (Exception ex)
{
    Console.WriteLine($"❌ Database connection error: {ex.Message}");
}

app.Run();