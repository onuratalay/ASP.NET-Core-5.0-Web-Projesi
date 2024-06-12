using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;

namespace CoreProje.Controllers
{
    [Authorize(Roles = "Admin")]

    public class TestimonialController : Controller
    {
        private TestimonialManager _testimonialManager = new TestimonialManager(new EfTestimonialDal());

        public IActionResult Index()
        {
            var values = _testimonialManager.TGetList();
            return View(values);
        }

        public IActionResult DeleteTestimonial(int id)
        {
            var value = _testimonialManager.TGetById(id);
            _testimonialManager.TDelete(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditTestimonial(int id)
        {
            var values = _testimonialManager.TGetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult EditTestimonial(Testimonial testimonial)
        {
            _testimonialManager.TUpdate(testimonial);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddTestimonial()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTestimonial(Testimonial testimonial)
        {
            _testimonialManager.TAdd(testimonial);
            return RedirectToAction("Index");
        }

    }
}
