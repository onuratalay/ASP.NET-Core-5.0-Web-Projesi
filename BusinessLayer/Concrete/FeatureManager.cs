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
    public class FeatureManager : IGenericService<Feature>
    {
        private IFeatureDal _featureDal;

        public FeatureManager(IFeatureDal featureDal)
        {
            _featureDal = featureDal;
        }
        public void TAdd(Feature t)
        {
            _featureDal.Insert(t);
        }

        public void TUpdate(Feature t)
        {
            _featureDal.Update(t);
        }

        public void TDelete(Feature t)
        {
            _featureDal.Delete(t);
        }

        public List<Feature> TGetList()
        {
            return _featureDal.GetList();
        }

        public Feature TGetById(int id)
        {
            return _featureDal.GetById(id);
        }

        public List<Feature> GetByFilter()
        {
            throw new NotImplementedException();
        }
    }
}
