using Microsoft.AspNetCore.Mvc;

namespace CoreProje.Controllers
{
    public class DefaultUserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
