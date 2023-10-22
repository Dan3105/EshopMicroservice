using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EshopMicroservice.Models
{
    [PrimaryKey(nameof(OrderId), nameof(ProductId))]
    public class OrderDetail
    {
        [ForeignKey("Order")]
        public int OrderId { get; set; }

        [Range(0, 100000)]
        public int quantity { set; get; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public virtual Order? Order { get; set; }
        public virtual Product? Product { get; set; }
    }
}
