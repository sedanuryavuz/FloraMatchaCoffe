
using System.ComponentModel.DataAnnotations.Schema;

namespace Flora.EntityLayer.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public string? Description { get; set; }
        [Column(TypeName ="Date")]
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public List<OrderDetail>? OrderDetails { get; set; }
        public int MenuTableId { get; set; }
        public MenuTable MenuTable { get; set; }
    }
}
