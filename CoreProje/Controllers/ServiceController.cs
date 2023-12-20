using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreProje.Controllers
{
    public class ServiceController : Controller
    {
        private ServiceManager _serviceManager = new ServiceManager(new EfServiceDal());

        public IActionResult Index()
        {
            ViewBag.v1 = "Düzenleme";
            ViewBag.v2 = "Hizmetler";
            ViewBag.v3 = "Hizmetler Listesi";
            var values = _serviceManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddService()
        {
            ViewBag.v1 = "Hizmet Ekle";
            ViewBag.v2 = "Hizmetler";
            ViewBag.v3 = "Hizmet Ekle";
            return View();
        }

        [HttpPost]
        public IActionResult AddService(Service service)
        {
            _serviceManager.TAdd(service);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteService(int id)
        {
            var values = _serviceManager.TGetById(id);
            _serviceManager.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditService(int id)
        {
            ViewBag.v1 = "Hizmet Güncelle";
            ViewBag.v2 = "Hizmetler";
            ViewBag.v3 = "Hizmet Güncelle";
            var values = _serviceManager.TGetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult EditService(Service service)
        {
            _serviceManager.TUpdate(service);
            return RedirectToAction("Index");
        }
    }
}
