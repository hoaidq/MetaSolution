using MetaSolution.ViewModels.Users;
using Microsoft.AspNetCore.Mvc;

namespace MetaSolution.AppAdmin.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginRequest request)
        {
            if (!ModelState.IsValid)
                return View(ModelState);

            ModelState.AddModelError("", "Abbbbbbbbbbbbbbbbccccccccccccccccc");
            return View();
        }    
    }
}
