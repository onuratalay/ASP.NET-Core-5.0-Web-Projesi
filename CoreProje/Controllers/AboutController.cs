using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreProje.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AboutController : Controller
    {
        private AboutManager _aboutManager = new AboutManager(new EfAboutDal());

        [HttpGet]
        public IActionResult Index()
        {
            var values = _aboutManager.TGetById(1);
            return View(values);
        }

        [HttpPost]
        public IActionResult Index(About about)
        {
            _aboutManager.TUpdate(about);
            return RedirectToAction("Index", "About");
        }
    }
}
