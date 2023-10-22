using System.ComponentModel.DataAnnotations;

namespace EshopMicroservice.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { set; get; }

        [Range(0, 1000000)]

        public float Price { set; get; }

        public int CategoryId { set; get; }

        public ICollection<OrderDetail> OrderDetails { set; get; }
    }
}
