﻿namespace Flora.WebUI.Dtos.CategoryDtos
{
    public class UpdateCategoryDto
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public bool CategoryStatus { get; set; }
        public string? CategoryCoverImg { get; set; }

    }
}
