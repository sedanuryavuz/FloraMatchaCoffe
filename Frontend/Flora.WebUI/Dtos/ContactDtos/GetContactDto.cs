﻿namespace Flora.WebUI.Dtos.ContactDto
{
    public class GetContactDto
    {
        public int ContactId { get; set; }
        public string? Location { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Mail { get; set; }
        public string? FooterDescription { get; set; }
    }
}
