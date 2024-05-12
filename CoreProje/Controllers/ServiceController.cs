using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreProje.Controllers
{
    [Authorize(Roles = "Admin")]

    public class ServiceController : Controller
    {
        private ServiceManager _serviceManager = new ServiceManager(new EfServiceDal());

        public IActionResult Index()
        {
            var values = _serviceManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddService()
        {
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
