namespace Flora.EntityLayer.Entities
{
    public class Discount
    {
        public int DiscountId { get; set; }
        public decimal Amount { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public bool Status { get; set; }
    }
}
