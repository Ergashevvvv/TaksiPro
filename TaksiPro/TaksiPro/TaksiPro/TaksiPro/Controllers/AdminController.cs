using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TaksiPro.Models;

namespace TaksiPro.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDbContext db;

        public AdminController(AppDbContext db)
        {
            this.db = db;
        }

        public IActionResult AdminMain()
        {
            return View();
        }

        // Xabarlar
        public IActionResult Xabar()
        {
            var xabarlar = db.Contactlar.ToList();
            return View(xabarlar);
        }

        // Tariflar
        public IActionResult Tariff()
        {
            var tariflar = db.Tarifflar.ToList();
            return View(tariflar);
        }

        [HttpGet]
        public IActionResult AddTarif()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddTarif(Tariff model)
        {
            if (ModelState.IsValid)
            {
                db.Tarifflar.Add(model);
                await db.SaveChangesAsync();

                TempData["SuccessMessage"] = "Tariff successfully added!";
                return RedirectToAction("Tariff");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var tariff = await db.Tarifflar.FindAsync(id);
            if (tariff != null)
            {
                db.Tarifflar.Remove(tariff);
                await db.SaveChangesAsync();
                TempData["SuccessMessage"] = "Tariff successfully deleted!";
            }
            else
            {
                TempData["ErrorMessage"] = "Tariff not found!";
            }
            return RedirectToAction("Tariff");
        }

        
        public IActionResult Buyurtma()
        {
            var buyurtmalar = db.Buyurtmalar
                                .Include(b => b.Tariff) 
                                .ToList();
            return View(buyurtmalar);
        }


        [HttpGet]
        public IActionResult AddBuyurtma()
        {
            
            ViewBag.Tariffs = new SelectList(db.Tarifflar.ToList(), "Id", "Name");
            return View();
        }


        [HttpPost]
        public IActionResult AddBuyurtma(Buyurtma model)
        {
            ViewBag.Tariffs = new SelectList(db.Tarifflar.ToList(), "Id", "Name");
           
                db.Buyurtmalar.Add(model);
                db.SaveChanges();

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> DeleteBuyurtma(int id)
        {
            var buyurtma = await db.Buyurtmalar.FindAsync(id);
            if (buyurtma != null)
            {
                db.Buyurtmalar.Remove(buyurtma);
                await db.SaveChangesAsync();
                TempData["SuccessMessage"] = "Buyurtma muvaffaqiyatli o'chirildi!";
            }
            else
            {
                TempData["ErrorMessage"] = "Buyurtma topilmadi!";
            }
            return RedirectToAction("Buyurtma");
        }
    }
}
