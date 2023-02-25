using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public bool Add(Car car)
        {
            if (car.Description.Length < 2 || car.DailyPrice <= 0)
            {
                return false;
            }
            else
            {
                _carDal.Add(car);
                return true;
            }
        }

        public bool Delete(Car car)
        {
            if (_carDal.Delete(car))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public Car GetById(int carId)
        {
            return _carDal.Get(c => c.Id == carId);
        }

        public List<Car> GetCarsBrandId(int id)
        {
            return _carDal.GetAll(c => c.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(c => c.ColorId == id);
        }

        public bool Update(Car car)
        {
            if (_carDal.Update(car))
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
