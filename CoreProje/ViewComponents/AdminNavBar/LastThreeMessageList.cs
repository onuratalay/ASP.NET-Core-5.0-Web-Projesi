using System.Linq;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreProje.ViewComponents.AdminNavBar
{
    public class LastThreeMessageList : ViewComponent
    {
        private WriterMessageManager _writerMessageManager = new WriterMessageManager(new EfWriterMessageDal());

        public IViewComponentResult Invoke()
        {
            string username = "admin";
            var values = _writerMessageManager.GetListReceiverMessage(username).OrderByDescending(x=>x.WriterMessageId).Take(3).ToList();
            return View(values);
        }
    }
}
