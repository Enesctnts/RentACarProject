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
            Console.WriteLine(carManager.Get(1).Description);



            //foreach (var item in carManager.Get(1))
            //{

            //}

            //Console.ReadLine();
        }
    }
}
