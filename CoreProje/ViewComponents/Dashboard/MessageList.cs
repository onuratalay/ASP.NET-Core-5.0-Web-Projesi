using System.Linq;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreProje.ViewComponents.Dashboard
{
    public class MessageList : ViewComponent
    {
        private MessageManager _messageManager = new MessageManager(new EfMessageDal());

        public IViewComponentResult Invoke()
        {
            var values = _messageManager.TGetList().OrderByDescending(x=>x.MessageId).Take(4).ToList();
            return View(values);
        }
    }
}
