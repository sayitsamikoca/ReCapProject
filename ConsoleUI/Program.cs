using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.ComponentModel.DataAnnotations;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car car1 = new Car
            {
                Id = 1, BrandId = 1, ColorId = 1, DailyPrice = 220, Description = "Beyaz Opel Astra", ModelYear = 2002
            };

            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(car1);
        }
    }
}
