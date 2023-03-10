using Core.DataAcces;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car {Id=1,BrandId=1,ColorId=1,ModelYear=2015,DailyPrice=500,Description="Mavi Opel Astra"},
                new Car {Id=2,BrandId=1,ColorId=2,ModelYear=2008,DailyPrice=225,Description="Siyah Opel Astra"},
                new Car {Id=3,BrandId=2,ColorId=3,ModelYear=2021,DailyPrice=875,Description="Beyaz Dacia Sandero"},
                new Car {Id=4,BrandId=2,ColorId=1,ModelYear=2022,DailyPrice=975,Description="Mavi Dacia Sandero"},
                new Car {Id=5,BrandId=3,ColorId=3,ModelYear=2019,DailyPrice=675,Description="Siyah Volvo"}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(p => p.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int id)
        {
            return _cars.Where(p => p.Id == id).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(p => p.Id == car.Id);

            carToUpdate.Id = car.Id;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }

        void IEntityRepository<Car>.Add(Car entity)
        {
            throw new NotImplementedException();
        }

        void IEntityRepository<Car>.Delete(Car entity)
        {
            throw new NotImplementedException();
        }

        void IEntityRepository<Car>.Update(Car entity)
        {
            throw new NotImplementedException();
        }
    }
}
