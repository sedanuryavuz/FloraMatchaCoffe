using Flora.DtoLayer.ProductDto;

namespace Flora.DtoLayer.CategoryDto
{
    public class UpdateCategoryDto
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public bool CategoryStatus { get; set; }
        public List<ResultProductDto>? Product { get; set; }
    }
}
