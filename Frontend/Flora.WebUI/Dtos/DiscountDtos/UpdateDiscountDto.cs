﻿namespace Flora.WebUI.Dtos.DiscountDto
{
    public class UpdateDiscountDto
    {
        public int DiscountId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Amount { get; set; }
        public string? ImageUrl { get; set; }
        public int ProductId { get; set; }
        public bool Status { get; set; }
    }
}
