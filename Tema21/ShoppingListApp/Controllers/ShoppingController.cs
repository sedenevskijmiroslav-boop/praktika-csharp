using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingListApp.Data;
using ShoppingListApp.Models;

namespace ShoppingListApp.Controllers
{
    public class ShoppingController : Controller
    {
        private readonly AppDbContext _db;

        public ShoppingController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var items = _db.ShoppingItems
                .AsNoTracking()
                .OrderBy(i => i.IsBought)
                .ThenBy(i => i.Name)
                .ToList();

            ViewBag.Items = items;
            ViewBag.Message = TempData["Message"] as string;

            return View(new ShoppingItemViewModel());
        }

        public IActionResult Add()
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(ShoppingItemViewModel model)
        {
            if (ModelState.IsValid)
            {
                _db.ShoppingItems.Add(new ShoppingItem
                {
                    Name = model.Name,
                    Quantity = model.Quantity,
                    IsBought = false
                });
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            var items = _db.ShoppingItems
                .AsNoTracking()
                .OrderBy(i => i.IsBought)
                .ThenBy(i => i.Name)
                .ToList();
            ViewBag.Items = items;
            return View("Index", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ToggleBought(int id, bool isBought)
        {
            var item = _db.ShoppingItems.FirstOrDefault(i => i.Id == id);
            if (item is not null)
            {
                item.IsBought = isBought;
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var item = _db.ShoppingItems.FirstOrDefault(i => i.Id == id);
            if (item is not null)
            {
                _db.ShoppingItems.Remove(item);
                _db.SaveChanges();
                TempData["Message"] = "Товар удалён";
            }
            return RedirectToAction("Index");
        }
    }
}