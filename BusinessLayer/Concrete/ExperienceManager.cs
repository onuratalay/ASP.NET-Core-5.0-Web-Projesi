﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class ExperienceManager : IExperienceService
    {
        private IExperienceDal _experienceDal;

        public ExperienceManager(IExperienceDal experienceDal)
        {
            _experienceDal = experienceDal;
        }

        public void TAdd(Experience t)
        {
            _experienceDal.Insert(t);
        }

        public void TUpdate(Experience t)
        {
            _experienceDal.Update(t);
        }

        public void TDelete(Experience t)
        {
            _experienceDal.Delete(t);
        }

        public List<Experience> TGetList()
        {
            return _experienceDal.GetList();
        }

        public Experience TGetById(int id)
        {
            return _experienceDal.GetById(id);
        }

        public List<Experience> GetByFilter()
        {
            throw new NotImplementedException();
        }
    }
}
