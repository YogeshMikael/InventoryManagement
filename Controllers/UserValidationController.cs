using InventoryManagementApplication.Data;
using Microsoft.AspNetCore.Mvc;


namespace InventoryManagementApplication.Controllers
{
    public class UserValidationController : Controller
    {
        private readonly InventoryContext _context;

        // GET: /<controller>/
        public UserValidationController(InventoryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
            if (user != null)
            {
                HttpContext.Session.SetString("Username", user.Username);
                return RedirectToAction("Items", "Items");
            }

            ViewBag.Error = "Invalid credentials";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}

