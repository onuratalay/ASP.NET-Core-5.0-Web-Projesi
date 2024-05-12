using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreProje.Controllers
{
    [Authorize(Roles = "Admin")]

    public class SkillController : Controller
    {
        private SkillManager manager = new SkillManager(new EfSkillDal());
        public IActionResult Index()
        {
            var values = manager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddSkill()
        {
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
