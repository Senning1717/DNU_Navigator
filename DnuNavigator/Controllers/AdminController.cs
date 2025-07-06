using Microsoft.AspNetCore.Mvc;

namespace DnuNavigator.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}