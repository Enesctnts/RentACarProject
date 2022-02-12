using Business.Concrete;
using DataAccess.Concrete.EntityFrameworkk;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            //BrandManager brandManager = new BrandManager(new EfBrandDal());

            //Brand brand1 = new Brand { BrandName = "JEEP" };
            //brandManager.Add(brand1);
            //Brand brand2 = new Brand { BrandName = "RENAULT" };
            //brandManager.Add(brand2);

            //ColorManager colorManager = new ColorManager(new EfColorDal());

            //Color color1 = new Color { ColorName = "YEŞİL" };
            //colorManager.Add(color1);
            //Color color2 = new Color {  ColorName = "SİYAH" };
            //colorManager.Add(color2);

            CarManager carManager = new CarManager(new EfCarDal());

            //Car car1 = new Car
            //{
            //    BrandId = 4,
            //    ColorId=3,
            //    Description= "RENAULT",
            //    DailyPrice=100,
            //    ModelYear=2000
            //};
            //carManager.Add(car1);
            //Car car2 = new Car
            //{
            //    BrandId = 3,
            //    ColorId = 4,
            //    Description = "JEEP",
            //    DailyPrice = 125,
            //    ModelYear = 2002
            //};
            //carManager.Add(car2);

            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine("Marka   : "+ car.BrandName);
                Console.WriteLine("Açıklama: "+ car.CarName);
                Console.WriteLine("Renk    :"+ car.ColorName);
                Console.WriteLine("G.Fiyat :"+ car.DailyPrice);
                Console.WriteLine();

            }



            Console.ReadLine();
        }
    }
}
