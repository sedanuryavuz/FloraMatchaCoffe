namespace Flora.EntityLayer.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? CategoryCoverImg { get; set; }
        public bool CategoryStatus { get; set; }
        public List<Product>? Products { get; set; }

    }
}
