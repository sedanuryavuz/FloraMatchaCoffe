namespace Flora.DtoLayer.ProductDto
{
    public class ProductWithDiscountDto
    {
        public int DiscountId { get; set; }
        public decimal Amount { get; set; }
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal DiscountedPrice { get; set; }
    }
}
