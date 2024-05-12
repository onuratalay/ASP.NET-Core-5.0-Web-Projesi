using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreProje.Controllers
{
    [Authorize(Roles = "Admin")]

    public class SocialMediaController : Controller
    {
        private SocialMediaManager _socialMediaManager = new SocialMediaManager(new EfSocialMediaDal());

        public IActionResult Index()
        {
            var values = _socialMediaManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddSocialMedia()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddSocialMedia(SocialMedia socialMedia)
        {
            socialMedia.Status = true;
            _socialMediaManager.TAdd(socialMedia);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteSocialMedia(int id)
        {
            var values = _socialMediaManager.TGetById(id);
            _socialMediaManager.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditSocialMedia(int id)
        {
            var values = _socialMediaManager.TGetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult EditSocialMedia(SocialMedia socialMedia)
        {
            _socialMediaManager.TUpdate(socialMedia);
            return RedirectToAction("Index");
        }
    }
}
