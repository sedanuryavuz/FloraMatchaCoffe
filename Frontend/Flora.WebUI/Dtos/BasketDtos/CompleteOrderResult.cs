namespace Flora.WebUI.Dtos.BasketDtos
{
    public class CompleteOrderResult
    {
        public string Message { get; set; }
        public int OrderId { get; set; }
        public string TableNumber { get; set; }
        public decimal TotalPrice { get; set; }
        public string QrCodeUrl { get; set; }
    }

}
