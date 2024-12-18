using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaksiPro.Models;
using TaksiPro.ModelViews;

namespace TaksiPro.Controllers
{
	public class HomeController : Controller
	{
		private readonly AppDbContext db;

		public HomeController(AppDbContext db)
		{
			this.db = db;
		}

		public IActionResult Index()
		{
			var moshinalar=db.Moshinaalar.ToList();
			return View(moshinalar);
		}		
		public IActionResult About()
		{
			return View();
		}
		public IActionResult Cars()
		{
			return View();
		}
		public IActionResult Services()
		{
	
			return View();
		}
		public ActionResult Contacts()
		{
			return View(new ContactViewModel());
		}



		public IActionResult SubmitContactForm()
		{
			return View();
		}

		[HttpPost]
		public IActionResult SubmitContactForm(ContactViewModel model)
		{
			if (ModelState.IsValid)
			{
				var can = new Contact()
				{
					Ism = model.Ism,
					Email = model.Email,
					PhoneNumber = model.PhoneNumber,
					Message = model.Message,
				};

				db.Contactlar.Add(can);
				db.SaveChanges();

				return RedirectToAction("Success");
			}
			return View(model);
		}

	
		public IActionResult Success()
		{
			return View();  
		}

		public IActionResult Details(int son)
		{ 
			var car=db.Moshinaalar.FirstOrDefault(c => c.Id == son);

			return View(car);

		}

	}
}
