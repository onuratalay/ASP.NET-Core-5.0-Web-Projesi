using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreProje.ViewComponents.SocialMedia
{
    public class SocialMediaList : ViewComponent
    {
        private SocialMediaManager _socialMediaManager = new SocialMediaManager(new EfSocialMediaDal());

        public IViewComponentResult Invoke()
        {
            var values = _socialMediaManager.TGetList();
            return View(values);
        }
    }
}
