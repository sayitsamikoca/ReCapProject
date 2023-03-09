using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
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

        public IResult Add(Brand brand)
        {
            if (string.IsNullOrWhiteSpace(brand.Name))
            {
                return new ErrorResult(Messages.NameInvalid);
            }
            else
            {
                _brandDal.Add(brand);
                return new SuccesResult(Messages.InsertSuccessful);
            }
        }

        public IResult Delete(Brand brand)
        {
            if (_brandDal.Delete(brand))
            {
                return new SuccesResult();
            }
            else
            {
                return new ErrorResult(Messages.DeleteFailed);
            }
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccesDataResult<List<Brand>>();
        }

        public IDataResult<Brand> GetById(int brandId)
        {
            return new SuccesDataResult<Brand>(_brandDal.Get(b => b.Id == brandId));
        }

        public IResult Update(Brand brand)
        {
            if (_brandDal.Update(brand))
            {
                return new SuccesResult(Messages.SuccessfullyUpdated);
            }
            else
            {
                return new ErrorResult(Messages.UpdateFailed);
            }
        }
    }
}
