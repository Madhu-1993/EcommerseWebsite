using System.ComponentModel.DataAnnotations;

namespace EcommerseWebsite.Models
{
    public class AddToCart
    {
        [Key]
        [ScaffoldColumn(false)]
        public int ItemId { get; set; }
        [Required]
        public string CartId { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int pid { get; set; }

    }
}
