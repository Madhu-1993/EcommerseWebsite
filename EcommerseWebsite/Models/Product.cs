using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerseWebsite.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Productid { get; set; }
        [Required]
        public string? Productname { get; set; }
        [Required]
        public int Discount { get; set; }
        [Required]
        public int? Stock { get; set; }
        [Required]
        public int? Price { get; set; }
        [Required]
        public string? Discription { get; set; }
        [NotMapped]
        public string? categoryname { get; set; }
        [Required]
        public int? categoryid { get; set; }
        //[NotMapped]
        public string? ImageUrl { get; set; }
    }
}
