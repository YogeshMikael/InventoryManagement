using Microsoft.AspNetCore.Mvc;
using InventoryManagementApplication.Data;
using InventoryManagementApplication.Models;
using System.Linq;

namespace InventoryManagementApplication.Controllers
{
    public class ItemsController : Controller
    {
        private readonly InventoryContext _context;

        public ItemsController(InventoryContext context)
        {
            _context = context;
        }

        // GET: /Items
        public IActionResult Items()
        {
            var items = _context.Items.ToList();
            return View("Items", items);
        }

        // GET: /CreateItems
        [HttpGet]
        public IActionResult CreateItems()
        {
            return View("CreateItems");
        }

        // POST: /CreateItems
        [HttpPost]
        public IActionResult CreateItems(Item item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Items.Add(item);
                    _context.SaveChanges();
                    return RedirectToAction("Items");
                }
                return View("CreateItems", item);
            }
            catch (Exception ex)
            {
                // Log or display the actual cause
                return Content($"Error: {ex.InnerException?.Message ?? ex.Message}");
            }

        }

        // GET: /updateItems/{id}
        [HttpGet]
        public IActionResult updateItems(int id)
        {
            var item = _context.Items.FirstOrDefault(i => i.Id == id);
            if (item == null) return NotFound();
            return View("updateItems", item);
        }

        // POST: /updateItems
        [HttpPost]
        public IActionResult updateItems(Item item)
        {
            if (ModelState.IsValid)
            {
                _context.Items.Update(item);
                _context.SaveChanges();
                return RedirectToAction("Items");
            }
            return View("updateItems", item);
        }

        // GET: /DeleteconfirmationItems/{id}
        [HttpGet]
        public IActionResult DeleteconfirmationItems(int id)
        {
            try
            {
                var item = _context.Items.FirstOrDefault(i => i.Id == id);
                if (item == null) return NotFound();
                return View("Deleteconfirmation", item);
            }
            catch (Exception ex)
            {
                // Log or display the actual cause
                return Content($"Error: {ex.InnerException?.Message ?? ex.Message}");
            }
        }

        // POST: /DeleteconfirmationItems
        [HttpPost, ActionName("DeleteconfirmationItems")]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                var item = _context.Items.FirstOrDefault(i => i.Id == id);
                if (item != null)
                {
                    _context.Items.Remove(item);
                    _context.SaveChanges();
                }
                return RedirectToAction("Items");
            }
            catch (Exception ex)
            {
                // Log or display the actual cause
                return Content($"Error: {ex.InnerException?.Message ?? ex.Message}");
            }

        }
    }
}
