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
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            return new SuccesResult(Messages.InsertSuccessful);
        }

        public IResult Delete(Rental rental)
        {
            if (_rentalDal.Delete(rental))
            {
                return new SuccesResult();
            }
            return new ErrorResult(Messages.DeleteFailed);

        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccesDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            return new SuccesDataResult<Rental>(_rentalDal.Get(r => r.Id == rentalId));
        }

        public IResult Update(Rental rental)
        {
            if (_rentalDal.Update(rental))
            {
                return new SuccesResult(Messages.SuccessfullyUpdated);
            }

            return new ErrorResult(Messages.UpdateFailed);
        }
    }
}
