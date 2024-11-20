using Microsoft.AspNetCore.Mvc;

namespace Lab5.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
