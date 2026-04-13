using Microsoft.AspNetCore.Mvc;
using ShoppingListApp.Models;
using ShoppingListApp.Services;
using System.Linq;

namespace ShoppingListApp.Controllers
{
    public class ShoppingController : Controller
    {
        private readonly IShoppingService _shoppingService;

        public ShoppingController(IShoppingService shoppingService)
        {
            _shoppingService = shoppingService;
        }

        public IActionResult Index()
        {
            var items = _shoppingService.GetAll();
            var notBought = items.Where(i => !i.Bought).ToList();
            var bought = items.Where(i => i.Bought).ToList();

            ViewBag.NotBought = notBought;
            ViewBag.Bought = bought;
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
                _shoppingService.Add(new ShoppingItem
                {
                    Name = model.Name,
                    Quantity = model.Quantity,
                    Bought = false
                });
                return RedirectToAction("Index");
            }

            var items = _shoppingService.GetAll();
            ViewBag.NotBought = items.Where(i => !i.Bought).ToList();
            ViewBag.Bought = items.Where(i => i.Bought).ToList();
            return View("Index", model);
        }

        public IActionResult Mark(int id)
        {
            _shoppingService.MarkAsBought(id);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var deleted = _shoppingService.Delete(id);
            if (deleted)
            {
                TempData["Message"] = "Товар удалён";
            }
            return RedirectToAction("Index");
        }

        public IActionResult Unmark(int id)
        {
            _shoppingService.Unmark(id);
            return RedirectToAction("Index");
        }
    }
}