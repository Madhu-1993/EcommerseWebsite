using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerseWebsite.Models
{
    [Table("Registration")]
    public class Registration
    {
        [Key]
        [ScaffoldColumn(false)]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
    }
}
