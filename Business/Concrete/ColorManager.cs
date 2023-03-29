using Business.Abstract;
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
            _colorDal.Delete(color);
            return new SuccesResult();
        }

        public IDataResult<List<Color>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Color>>(Messages.MaintenanceTime);
            }

            else
            {
                return new SuccesDataResult<List<Color>>(_colorDal.GetAll());
            }

        }

        public IDataResult<Color> GetById(int colorId)
        {
            return new SuccesDataResult<Color>(_colorDal.Get(c => c.Id == colorId));
        }

        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccesResult(Messages.SuccessfullyUpdated);
        }
    }
}
