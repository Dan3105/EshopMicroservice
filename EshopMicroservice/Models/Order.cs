using System.ComponentModel.DataAnnotations;

namespace EshopMicroservice.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }

        public ICollection<OrderDetail>? OrderDetails { get; set; }
    }
}
