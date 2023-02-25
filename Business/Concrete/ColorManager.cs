using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
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
        public bool Add(Color color)
        {
            if (string.IsNullOrWhiteSpace(color.Name))
            {
                return false;
            }
            else
            {
                _colorDal.Add(color);
                return true;
            }
        }

        public bool Delete(Color color)
        {
            if (_colorDal.Delete(color))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Color> GetAll()
        {
            return _colorDal.GetAll();
        }

        public Color GetById(int colorId)
        {
            return _colorDal.Get(c => c.Id == colorId);
        }

        public bool Update(Color color)
        {
            if (_colorDal.Update(color))
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
