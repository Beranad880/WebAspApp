using System.ComponentModel.DataAnnotations;

namespace WebAspApp.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Název produktu je povinný")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Název musí být mezi 2-100 znaky")]
        public string Name { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Popis může mít maximálně 500 znaků")]
        public string Description { get; set; } = string.Empty;

        [Range(0, int.MaxValue, ErrorMessage = "Cena musí být nezáporná")]
        public decimal Price { get; set; }
    }
}
