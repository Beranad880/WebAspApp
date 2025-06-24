using AutoMapper;
using WebAspApp.DTOs;
using WebAspApp.Models;
using WebAspApp.Repositories;

namespace WebAspApp.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetAllAsync()
        {
            var products = await _repo.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public async Task<ProductDTO?> GetByIdAsync(int id)
        {
            var product = await _repo.GetByIdAsync(id);
            return product == null ? null : _mapper.Map<ProductDTO>(product);
        }

        // ✅ Správná implementace s ProductCreateDTO
        public async Task<ProductDTO> AddAsync(ProductCreateDTO dto)
        {
            var product = _mapper.Map<Product>(dto);
            var added = await _repo.AddAsync(product);
            return _mapper.Map<ProductDTO>(added);
        }

        public async Task<ProductDTO?> UpdateAsync(ProductDTO dto)
        {
            var product = _mapper.Map<Product>(dto);
            var updated = await _repo.UpdateAsync(product);
            return updated == null ? null : _mapper.Map<ProductDTO>(updated);
        }

        public async Task<bool> DeleteAsync(int id) => await _repo.DeleteAsync(id);
    }
}