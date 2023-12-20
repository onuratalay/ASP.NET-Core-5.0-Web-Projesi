using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreProje.Controllers
{
    public class ExperienceController : Controller
    {
        private ExperienceManager manager = new ExperienceManager(new EfExperienceDal());

        public IActionResult Index()
        {
            ViewBag.v1 = "Deneyim Listesi";
            ViewBag.v2 = "Deneyimler";
            ViewBag.v3 = "Deneyim Listesi";
            var values = manager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddExperience()
        {
            ViewBag.v1 = "Deneyim Ekle";
            ViewBag.v2 = "Deneyimler";
            ViewBag.v3 = "Deneyim Ekle";
            return View();
        }

        [HttpPost]
        public IActionResult AddExperience(Experience experience)
        {
            manager.TAdd(experience);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteExperience(int id)
        {
            var values = manager.TGetById(id);
            manager.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditExperience(int id)
        {
            ViewBag.v1 = "Deneyim Güncelle";
            ViewBag.v2 = "Deneyimler";
            ViewBag.v3 = "Deneyim Güncelle";
            var values = manager.TGetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult EditExperience(Experience experience)
        {
            manager.TUpdate(experience);
            return RedirectToAction("Index");
        }
    }
}
