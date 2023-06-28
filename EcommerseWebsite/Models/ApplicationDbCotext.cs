using Microsoft.EntityFrameworkCore;
namespace EcommerseWebsite.Models
{
    public class ApplicationDbCotext:DbContext
    {
        public ApplicationDbCotext(DbContextOptions<ApplicationDbCotext>options):base(options) 
        {
        }
       public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get;set; }
        public DbSet<User> Users { get; set; }

    }
}
