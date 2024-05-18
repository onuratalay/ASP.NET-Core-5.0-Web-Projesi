using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoreProje.Controllers
{
    [Authorize(Roles = "Admin")]

    public class Contact2Controller : Controller
    {
        // Bu controller özelinde AJAX denemesi yapıldı ve başarıyla çalıştırıldı.
        
        private MessageManager _messageManager = new MessageManager(new EfMessageDal());

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListContact()
        {
            var values = JsonConvert.SerializeObject(_messageManager.TGetList());
            return Json(values);
        }

        [HttpPost]
        public IActionResult AddContact(Message message)
        {
            _messageManager.TAdd(message);
            var values = JsonConvert.SerializeObject(message);
            return Json(values);
        }

        public IActionResult GetById(int MessageId)
        {
            var messages = _messageManager.TGetById(MessageId);
            var values = JsonConvert.SerializeObject(messages);
            return Json(values);
        }

        public IActionResult DeleteContact(int MessageId)
        {
            var message = _messageManager.TGetById(MessageId);
            _messageManager.TDelete(message);
            return NoContent();
        }
    }
}
