using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreProje.Controllers
{
    public class FeatureController : Controller
    {
        private FeatureManager _featureManager = new FeatureManager(new EfFeatureDal());

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.v1 = "Düzenleme";
            ViewBag.v2 = "Öne Çıkanlar";
            ViewBag.v3 = "Öne Çıkan Sayfası";
            var values = _featureManager.TGetById(1);
            return View(values);
        }

        [HttpPost]
        public IActionResult Index(Feature feature)
        {
            _featureManager.TUpdate(feature);
            return RedirectToAction("Index","Default");
        }
    }
}
