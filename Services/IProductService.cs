using WebAspApp.DTOs;

namespace WebAspApp.Services
{
    public interface IProductService
    {

        Task<IEnumerable<ProductDTO>> GetAllAsync();
        Task<ProductDTO?> GetByIdAsync(int id);
        Task<ProductDTO> AddAsync(ProductCreateDTO product); 
        Task<ProductDTO?> UpdateAsync(ProductDTO product);
        Task<bool> DeleteAsync(int id);
    }
}
