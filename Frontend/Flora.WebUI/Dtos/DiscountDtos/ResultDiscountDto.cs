namespace Flora.WebUI.Dtos.DiscountDto
{
    public class ResultDiscountDto
    {
        public int DiscountId { get; set; }
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public string? Amount { get; set; }
        public string? ImageUrl { get; set; }
        public int ProductId { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal? DiscountedPrice { get; set; }
        public bool Status { get; set; }

    }
}
