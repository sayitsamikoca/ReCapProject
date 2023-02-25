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
                Id=5,BrandId=2 ,ColorId = 1, DailyPrice = 320, Description = "Beyaz Volkswagen BluMotion", ModelYear = 2012
            };

            Color color1 = new Color
            {
                Id = 2,
                Name = "Siyah"
            };

            Brand brand1 = new Brand
            {
                Id = 2,
                Name = "Volkswagen"
            };

            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(car1);
            // carManager.Delete(car1);

            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(brand1);

            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(color1);
        }
    }
}
