using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerseWebsite.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Userid { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Pmail { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public int Roleid { get; set; }
        [NotMapped]
        public string Rolename { get; set; }
    }
}
