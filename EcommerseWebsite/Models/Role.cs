using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerseWebsite.Models
{
    [Table("Roles")]
    public class Role
    {
        [Key]
        [ScaffoldColumn(false)]
        public int roleid { get; set; }
        [Required]
        public string rollname { get; set; }
    }
}
