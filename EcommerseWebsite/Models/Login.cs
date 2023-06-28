using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerseWebsite.Models
{
    [Table("TableLogin")]
    public class Login
    {
        [Key]
        [ScaffoldColumn(false)]
        public int id { get; set; }
        [Required]
        public int name { get; set; }
        [Required]
        public int password { get; set; }
    }
}
