# WebAspApp 🚀

**Modern ASP.NET Core Web API** pro správu produktů s kompletní CRUD funkcionalitou.

## 📋 Popis

WebAspApp je robustní REST API aplikace postavená na ASP.NET Core 9.0, která implementuje moderní architektonické vzory včetně Repository pattern, Dependency Injection a AutoMapper. Aplikace poskytuje kompletní správu produktů s validací, databázovými migracemi a automatickou dokumentací.

## ✨ Hlavní funkce

- **CRUD operace** pro produkty
- **Automatické validace** s chybovými hláškami v češtině
- **Entity Framework Core** s SQL Server
- **AutoMapper** pro objektové mapování
- **Swagger/OpenAPI** dokumentace
- **Repository pattern** pro čistou architekturu
- **Health checks** pro monitoring
- **Automatické databázové migrace** při startu

## 🛠️ Technologie

- **ASP.NET Core 9.0**
- **Entity Framework Core 9.0**
- **SQL Server**
- **AutoMapper 12.0**
- **Swagger/OpenAPI**
- **FluentValidation**
- **MediatR** (připraveno)
- **Hangfire** (připraveno)
- **Serilog** (připraveno)

## 📁 Struktura projektu

```
WebAspApp/
├── Controllers/          # API kontrolery
├── DTOs/                # Data Transfer Objects
├── Models/              # Entity modely
├── Services/            # Business logika
├── Repositories/        # Data access layer
├── Data/                # DbContext
├── Mappings/            # AutoMapper profily
├── Migrations/          # EF Core migrace
└── appsettings.json     # Konfigurace
```

## 🚀 Rychlý start

### Požadavky
- .NET 9.0 SDK
- SQL Server (LocalDB/Express/Full)
- Visual Studio 2022 nebo VS Code

### Instalace

1. **Klonování repozitáře**
   ```bash
   git clone <repository-url>
   cd WebAspApp
   ```

2. **Nastavení databáze**
   - Upravte connection string v `appsettings.json`
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=YOUR_SERVER;Database=YOUR_DB;Trusted_Connection=true;TrustServerCertificate=true;"
     }
   }
   ```

3. **Spuštění aplikace**
   ```bash
   dotnet restore
   dotnet run
   ```

4. **Otevření Swagger dokumentace**
   - Navigujte na: `https://localhost:7XXX/swagger`

## 📊 API Endpoints

### Products API

| Metoda | Endpoint | Popis |
|--------|----------|-------|
| `GET` | `/api/product` | Získání všech produktů |
| `GET` | `/api/product/{id}` | Získání produktu podle ID |
| `POST` | `/api/product` | Vytvoření nového produktu |
| `PUT` | `/api/product/{id}` | Aktualizace produktu |
| `DELETE` | `/api/product/{id}` | Smazání produktu |

### Příklad požadavku (POST)

```json
{
  "name": "iPhone 15",
  "description": "Nejnovější iPhone s pokročilými funkcemi",
  "price": 25990
}
```

### Příklad odpovědi (GET)

```json
{
  "id": 1,
  "name": "iPhone 15",
  "description": "Nejnovější iPhone s pokročilými funkcemi",
  "price": 25990.00
}
```

## 🏗️ Architektura

### Vzory a principy
- **Repository Pattern** - Abstrakce nad datovou vrstvou
- **Dependency Injection** - Loose coupling
- **DTO Pattern** - Separace API a doménových modelů
- **Service Layer** - Business logika

### Datový model

```csharp
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }        // Max 100 znaků
    public string Description { get; set; }  // Max 500 znaků
    public decimal Price { get; set; }       // Nezáporná hodnota
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
```

## 🔧 Konfigurace

### Důležité nastavení

- **Connection String**: Upravte v `appsettings.json`
- **Logging**: Konfigurace v `Program.cs`
- **Health Checks**: Endpoint `/health`
- **CORS**: Není nakonfigurován (přidejte dle potřeby)

### Environment Variables

Pro produkční prostředí doporučujeme používat:
- `ASPNETCORE_ENVIRONMENT=Production`
- Connection string přes Azure Key Vault nebo podobné

## 🧪 Testování

### Manuální testování
1. Spusťte aplikaci: `dotnet run`
2. Otevřete Swagger UI
3. Testujte jednotlivé endpointy

### Automatické testy
```bash
# Připraveno pro unit testy
dotnet test
```

## 📈 Rozšíření

Projekt je připraven pro následující rozšíření:

- **Autentifikace/Autorizace** (JWT tokeny)
- **Caching** (Redis)
- **Background Jobs** (Hangfire)
- **Logging** (Serilog)
- **Monitoring** (Application Insights)
- **Versioning** API
- **Rate Limiting**

## 🔍 Health Checks

Aplikace obsahuje health check endpoint:
- **URL**: `/health`
- **Kontroluje**: Databázové připojení
- **Použití**: Monitoring, Load Balancer

## 🐛 Troubleshooting

### Časté problémy

1. **Databázové připojení**
   - Zkontrolujte connection string
   - Ověřte, že SQL Server běží
   
2. **Migrace**
   - Migrace se spouští automaticky při startu
   - Manuálně: `dotnet ef database update`

3. **Port konflikty**
   - Změňte port v `Properties/launchSettings.json`

