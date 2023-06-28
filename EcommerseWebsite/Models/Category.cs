using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerseWebsite.Models
{
    [Table("Catagories")]
    public class Category
    {
        [Key]
        [ScaffoldColumn(false)]
        public int categoryid { get; set; }
        [Required]
        public string categoryname { get; set; }
    }
}
