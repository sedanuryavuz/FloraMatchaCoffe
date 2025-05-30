using Flora.DtoLayer.ProductDto;

namespace Flora.DtoLayer.CategoryDto
{
    public class ResultCategoryDto
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public bool CategoryStatus { get; set; }
        public List<ResultProductDto>? Products { get; set; }
    }
}
