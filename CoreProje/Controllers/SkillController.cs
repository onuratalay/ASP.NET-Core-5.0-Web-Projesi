using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreProje.Controllers
{
    public class SkillController : Controller
    {
        private SkillManager manager = new SkillManager(new EfSkillDal());
        public IActionResult Index()
        {
            ViewBag.v1 = "Yetenek Listesi";
            ViewBag.v2 = "Yetenekler";
            ViewBag.v3 = "Yetenek Listesi";
            var values = manager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddSkill()
        {
            ViewBag.v1 = "Yetenek Ekle";
            ViewBag.v2 = "Yetenekler";
            ViewBag.v3 = "Yetenek Ekle";
            return View();
        }

        [HttpPost]
        public IActionResult AddSkill(Skill skill)
        {
            manager.TAdd(skill);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteSkill(int id)
        {
            var values = manager.TGetById(id);
            manager.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditSkill(int id)
        {
            ViewBag.v1 = "Yetenek Güncelle";
            ViewBag.v2 = "Yetenekler";
            ViewBag.v3 = "Yetenek Güncelle";
            var values = manager.TGetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult EditSkill(Skill skill)
        {
            manager.TUpdate(skill);
            return RedirectToAction("Index");
        }
    }
}
