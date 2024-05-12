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
    public class MessageManager : IMessageService
    {
        private IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }
        public void TAdd(Message t)
        {
            _messageDal.Insert(t);
        }

        public void TUpdate(Message t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Message t)
        {
            _messageDal.Delete(t);
        }

        public List<Message> TGetList()
        {
            return _messageDal.GetList();
        }

        public Message TGetById(int id)
        {
            return _messageDal.GetById(id);
        }

        public List<Message> GetByFilter()
        {
            throw new NotImplementedException();
        }
    }
}
