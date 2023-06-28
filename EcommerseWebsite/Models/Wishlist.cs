using System.ComponentModel.DataAnnotations;

namespace EcommerseWebsite.Models
{
    public class Wishlist
    {
        [Key]
        [ScaffoldColumn(false)]
        public int pid { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string description { get; set; }

    }
}
