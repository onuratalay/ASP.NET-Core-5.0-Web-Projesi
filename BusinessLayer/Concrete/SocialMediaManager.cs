using BusinessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class SocialMediaManager : ISocialMediaService
    {
        private ISocialMediaDal _socialMediaDal;

        public SocialMediaManager(ISocialMediaDal socialMediaDal)
        {
            _socialMediaDal = socialMediaDal;
        }

        public void TAdd(SocialMedia t)
        {
            _socialMediaDal.Insert(t);
        }

        public void TUpdate(SocialMedia t)
        {
            _socialMediaDal.Update(t);
        }

        public void TDelete(SocialMedia t)
        {
            _socialMediaDal.Delete(t);
        }

        public List<SocialMedia> TGetList()
        {
            return _socialMediaDal.GetList();
        }

        public SocialMedia TGetById(int id)
        {
            return _socialMediaDal.GetById(id);
        }
    }
}
