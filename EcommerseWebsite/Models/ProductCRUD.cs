using Microsoft.Identity.Client;

namespace EcommerseWebsite.Models
{
    public class ProductCRUD
    {
        private readonly ApplicationDbCotext db;
        public ProductCRUD(ApplicationDbCotext db)
        {
            this.db = db;
        }
        public IEnumerable<Product> GetProducts()
        {
            return db.Products.ToList();
        }
        public Product GetProductById(int id) 
        {
            var result=db.Products.Where(x=>x.Productid== id).FirstOrDefault();
            return result;
        }
        public int AddProduct(Product product)
        {
            int result = 0;
            db.Products.Add(product);
            result=db.SaveChanges();
            return result;
        }
        public int EditProduct(Product product)
        {
            int result = 0;
            var prod=db.Products.Where(x=>x.Productid==product.Productid).FirstOrDefault();
            if(prod!=null)
            {
                prod.Productname= product.Productname;
                prod.Discount= product.Discount;
                prod.Stock= product.Stock;
                prod.Price= product.Price;
                prod.Discription= product.Discription;
                prod.ImageUrl= product.ImageUrl;
                result = db.SaveChanges();
            }
            return result;
        }
        public int DeleteProduct(int id)
        {
            int result = 0;
            var prod = db.Products.Where(x => x.Productid == id).FirstOrDefault();
            if(prod!=null)
            {
                db.Products.Remove(prod);
                result = db.SaveChanges();
            }
            return result;
        }
    }
}
