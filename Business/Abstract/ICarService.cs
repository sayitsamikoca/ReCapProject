using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        List<Car> GetCarsBrandId(int id);
        List<Car> GetCarsByColorId(int id);
        bool Add(Car car);
        bool Update(Car car);
        bool Delete(Car car);
        Car GetById(int carId);
    }
}
