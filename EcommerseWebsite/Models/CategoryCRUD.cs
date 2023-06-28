using NuGet.Protocol;
using Microsoft.EntityFrameworkCore;
namespace EcommerseWebsite.Models
{
	public class CategoryCRUD
	{
		private readonly ApplicationDbCotext db;
		public CategoryCRUD(ApplicationDbCotext db)
		{
			this.db = db;
		}
		public IEnumerable<Category> GetCategories()
		{
			return db.Categories.ToList();
		}
		public Category GetCategoryById(int id)
		{
			var result=db.Categories.Where(x=>x.categoryid==id).FirstOrDefault();
			return result;
		}
		public int AddCategories(Category cat)
		{
			int result = 0;
            db.Categories.Add(cat);
			result = db.SaveChanges();
			return result;
		}

		public int EditCategories(Category cat)
		{
			int result = 0;
			var c = db.Categories.Where(x => x.categoryid == cat.categoryid).FirstOrDefault();
			if(c!=null)
			{
				c.categoryname = cat.categoryname;
				result=db.SaveChanges();
			}
			return result;
		}

		public int DeleteCategories(int id)
		{ 
			int result=0;
			var c = db.Categories.Where(x => x.categoryid == id).FirstOrDefault();
			if(c!=null)
			{
				db.Categories.Remove(c);
				result = db.SaveChanges();
			}
			return result;
		}
		

		
	}
}
