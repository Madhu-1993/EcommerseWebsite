using EcommerseWebsite.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Design.Internal;

namespace EcommerseWebsite.Controllers
{
	public class CategoryController : Controller
	{
		private readonly ApplicationDbCotext db;
		private CategoryCRUD crud;
		public CategoryController(ApplicationDbCotext db)
		{
			this.db = db;
			crud = new CategoryCRUD(this.db);
		}

		// GET: CategoryController
		public ActionResult Index()
		{
			var list = crud.GetCategories();
			return View(list);
		}

		// GET: CategoryController/Details/5
		public ActionResult Details(int categoryid)
		{
			var c = crud.GetCategoryById(categoryid);
			return View(c);
		}

		// GET: CategoryController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: CategoryController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(Category category)
		{
			try
			{
				int result = crud.AddCategories(category);
				if(result>0)
				return RedirectToAction(nameof(Index));
				return View();
			}
			catch
			{
				return View();
			}
		}

		// GET: CategoryController/Edit/5
		public ActionResult Edit(int categoryid)
		{
			var c = crud.GetCategoryById(categoryid);
			return View();
		}

		// POST: CategoryController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(Category category)
		{
			try
			{
				int result = crud.EditCategories(category);
				if(result>0)
				return RedirectToAction(nameof(Index));
				return View();
			}
			catch
			{
				return View();
			}
		}

		// GET: CategoryController/Delete/5
		public ActionResult Delete(int categoryid)
		{
			var c = crud.GetCategoryById(categoryid);
			return View(c);
		}

		// POST: CategoryController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		[ActionName("Delete")]
		public ActionResult DeleteConfirm(int categoryid)
		{
			try
			{
				int result = crud.DeleteCategories(categoryid);
				if(result>0)
				return RedirectToAction(nameof(Index));
				return View();			
			}
			catch
			{
				return View();
			}
		}
	}
}
