using System.ComponentModel.DataAnnotations;

namespace EshopMicroservice.Models
{
    public class Category
    {
        [Key]
        public int Id { set; get; }

        [Required]
        public string Name { set; get; }

        public string Description { set; get; }
    }
}
