﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;
        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }
        public IResult Add(Color color)
        {
            if (string.IsNullOrWhiteSpace(color.Name))
            {
                // return false;
                return new ErrorResult(Messages.NameInvalid);
            }
            else
            {
                _colorDal.Add(color);
                return new SuccesResult(Messages.InsertSuccessful);
            }
        }

        public IResult Delete(Color color)
        {
            if (_colorDal.Delete(color))
            {
                return new SuccesResult();
            }
            else
            {
                return new ErrorResult(Messages.DeleteFailed);
            }
        }

        public IDataResult<List<Color>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Color>>(Messages.MaintenanceTime);
            }

            else
            {
                return new SuccesDataResult<List<Color>>();
            }

        }

        public IDataResult<Color> GetById(int colorId)
        {
            return new SuccesDataResult<Color>(_colorDal.Get(c => c.Id == colorId));
        }

        public IResult Update(Color color)
        {
            if (_colorDal.Update(color))
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
