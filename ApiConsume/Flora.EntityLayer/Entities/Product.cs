﻿namespace Flora.EntityLayer.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public bool ProductStatus { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public List<OrderDetail>? OrderDetails { get; set; }
        public Discount? Discount { get; set; }
        public List<Basket>? Baskets { get; set; }

    }
}
