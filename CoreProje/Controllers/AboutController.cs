using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreProje.Controllers
{
    public class AboutController : Controller
    {
        private AboutManager _aboutManager = new AboutManager(new EfAboutDal());

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.v1 = "Düzenleme";
            ViewBag.v2 = "Hakkımda";
            ViewBag.v3 = "Hakkımda Sayfası";
            var values = _aboutManager.TGetById(1);
            return View(values);
        }

        [HttpPost]
        public IActionResult Index(About about)
        {
            _aboutManager.TUpdate(about);
            return RedirectToAction("Index", "Default");
        }
    }
}
