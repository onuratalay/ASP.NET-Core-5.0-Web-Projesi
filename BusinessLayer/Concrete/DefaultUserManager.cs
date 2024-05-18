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
    public class DefaultUserManager : IDefaultUserService
    {
        private IDefaultUserDal _defaultUserDal;

        public DefaultUserManager(IDefaultUserDal defaultUserDal)
        {
            _defaultUserDal = defaultUserDal;
        }

        public void TAdd(DefaultUser t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(DefaultUser t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(DefaultUser t)
        {
            throw new NotImplementedException();
        }

        public List<DefaultUser> TGetList()
        {
            return _defaultUserDal.GetList();
        }

        public DefaultUser TGetById(int id)
        {
            return _defaultUserDal.GetById(id);
        }
    }
}
