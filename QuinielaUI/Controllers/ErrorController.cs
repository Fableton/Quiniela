using Helpers;
using Microsoft.AspNetCore.Mvc;

namespace QuinielaUI.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Unauthorized()
        {
            return View();
        }
    }
}
