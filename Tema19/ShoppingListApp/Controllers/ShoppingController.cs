using Microsoft.AspNetCore.Mvc;
using ShoppingListApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingListApp.Controllers
{
    public class ShoppingController : Controller
    {
        private static List<ShoppingItem> _items = new List<ShoppingItem>();
        private static int _nextId = 1;

        public ShoppingController()
        {
            if (_items.Count == 0)
            {
                _items.Add(new ShoppingItem { Id = _nextId++, Name = "Молоко", Quantity = 2, Bought = false });
                _items.Add(new ShoppingItem { Id = _nextId++, Name = "Хлеб", Quantity = 1, Bought = false });
                _items.Add(new ShoppingItem { Id = _nextId++, Name = "Яйца", Quantity = 10, Bought = true });
                _items.Add(new ShoppingItem { Id = _nextId++, Name = "Масло", Quantity = 1, Bought = false });
            }
        }

        public IActionResult Index()
        {
            var notBought = _items.Where(i => !i.Bought).ToList();
            var bought = _items.Where(i => i.Bought).ToList();

            ViewBag.NotBought = notBought;
            ViewBag.Bought = bought;

            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(ShoppingItem item)
        {
            if (ModelState.IsValid)
            {
                item.Id = _nextId++;
                item.Bought = false; 
                _items.Add(item);
                return RedirectToAction("Index");
            }
            return View(item);
        }

        public IActionResult Mark(int id)
        {
            var item = _items.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                item.Bought = true; 
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var item = _items.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                _items.Remove(item);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Unmark(int id)
        {
            var item = _items.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                item.Bought = false;
            }
            return RedirectToAction("Index");
        }
    }
}