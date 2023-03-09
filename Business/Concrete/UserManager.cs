using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            return new SuccesResult(Messages.InsertSuccessful);
        }

        public IResult Delete(User user)
        {
            if (_userDal.Delete(user))
            {
                return new SuccesResult();
            }
            return new ErrorResult(Messages.DeleteFailed);
         
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccesDataResult<List<User>>(_userDal.GetAll());
        }

        public IDataResult<User> GetById(int userId)
        {
            return new SuccesDataResult<User>(_userDal.Get(u => u.Id == userId));
        }

        public IResult Update(User user)
        {
            if (_userDal.Update(user))
            {
                return new SuccesResult(Messages.SuccessfullyUpdated);
            }

            return new ErrorResult(Messages.UpdateFailed);
        }
    }
}
