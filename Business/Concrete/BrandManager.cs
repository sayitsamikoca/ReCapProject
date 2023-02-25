using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public bool Add(Brand brand)
        {
            if (string.IsNullOrWhiteSpace(brand.Name))
            {
                return false;
            }
            else
            {
                _brandDal.Add(brand);
                return true;
            }
        }

        public bool Delete(Brand brand)
        {
            if (_brandDal.Delete(brand))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public Brand GetById(int brandId)
        {
            return _brandDal.Get(b => b.Id == brandId);
        }

        public bool Update(Brand brand)
        {
            if (_brandDal.Update(brand))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
