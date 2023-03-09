using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer customer)
        {
            return new SuccesResult(Messages.InsertSuccessful);
        }

        public IResult Delete(Customer customer)
        {
            if (_customerDal.Delete(customer))
            {
                return new SuccesResult();
            }
            return new ErrorResult(Messages.DeleteFailed);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccesDataResult<List<Customer>>(_customerDal.GetAll());
        }

        public IDataResult<Customer> GetById(int customerId)
        {
            return new SuccesDataResult<Customer>(_customerDal.Get(c => c.UserId == customerId));
        }

        public IResult Update(Customer customer)
        {
            if (_customerDal.Update(customer))
            {
                return new SuccesResult(Messages.SuccessfullyUpdated);
            }

            return new ErrorResult(Messages.UpdateFailed);
        }
    }
}
