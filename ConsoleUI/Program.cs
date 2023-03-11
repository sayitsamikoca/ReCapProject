using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.ComponentModel.DataAnnotations;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // CRUDTest();
            //CarDetailsTest();
            //GetCarDetailsResultsTest();

            Customer customer1 = new Customer { Id=2,UserId = 1, CompanyName = "TestCompanyTwo" };
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var result = customerManager.Add(customer1);

            if (result.Succes)
            {
                Console.WriteLine(result.Message);
            }



        }

        private static void GetCarDetailsResultsTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetails();

            if (result.Succes)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarName + " / " + car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
        private static void CarDetailsTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            /*
            foreach (var item in carManager.GetCarDetails())
            {
                Console.WriteLine
                    (
                    item.CarName + "/" +
                    item.BrandName + "/" +
                    item.ColorName + "/" +
                    item.DailyPrice
                    );
            }
            */
        }
        private static void CRUDTest()
        {
            Car car1 = new Car
            {
                Id = 5,
                BrandId = 2,
                ColorId = 1,
                DailyPrice = 320,
                Description = "Beyaz Volkswagen BluMotion",
                ModelYear = 2012
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
