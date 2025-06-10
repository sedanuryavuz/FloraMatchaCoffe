﻿namespace Flora.EntityLayer.Entities
{
    public class Basket
    {
        public int BasketId { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public decimal TotalPrice { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public int MenuTableId { get; set; }
        public MenuTable? MenuTable { get; set; }
        public bool IsOrdered { get; set; }
    }
}
