using Business.Concrete;
using DataAccess.Concrete.EntityFrameworkk;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Id + " " + car.DailyPrice + " " + car.Description);
            }

            Console.ReadLine();
        }
    }
}
