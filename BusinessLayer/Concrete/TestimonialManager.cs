using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class TestimonialManager : ITestimonialService
    {
        private ITestimonialDal _testimonialDal;

        public TestimonialManager(ITestimonialDal testimonialDal)
        {
            _testimonialDal = testimonialDal;
        }

        public void TAdd(Testimonial t)
        {
            _testimonialDal.Insert(t);
        }

        public void TUpdate(Testimonial t)
        {
            _testimonialDal.Update(t);
        }

        public void TDelete(Testimonial t)
        {
            _testimonialDal.Delete(t);
        }

        public List<Testimonial> TGetList()
        {
            return _testimonialDal.GetList();
        }

        public Testimonial TGetById(int id)
        {
            return _testimonialDal.GetById(id);
        }
    }
}
