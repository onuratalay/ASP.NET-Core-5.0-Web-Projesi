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
    public class ContactManager : IContactService
    {
        private IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }
        public void TAdd(Contact t)
        {
            _contactDal.Insert(t);
        }

        public void TUpdate(Contact t)
        {
            _contactDal.Update(t);
        }

        public void TDelete(Contact t)
        {
            throw new NotImplementedException();
        }

        public List<Contact> TGetList()
        {
            return _contactDal.GetList();
        }

        public Contact TGetById(int id)
        {
            return _contactDal.GetById(id);
        }

        public List<Contact> GetByFilter()
        {
            throw new NotImplementedException();
        }
    }
}
