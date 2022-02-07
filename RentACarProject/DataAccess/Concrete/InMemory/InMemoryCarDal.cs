using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemoryCarDal
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _car;
        public InMemoryCarDal()
        {
            _car = new List<Car>
            {
                new Car {BrandId=1,ColorId=1,Id=1,DailyPrice=900,ModelYear=2022,Description="Yeni Model Araç"},
                new Car {BrandId=1,ColorId=2,Id=2,DailyPrice=1000,ModelYear=2014,Description="Spor Araba"},
                new Car {BrandId=1,ColorId=3,Id=3,DailyPrice=800,ModelYear=2020,Description="Üstü Açık"},
                new Car {BrandId=2,ColorId=1,Id=4,DailyPrice=2000,ModelYear=1990,Description="Antika"},
            };
        }

        public void Add(Car car)
        {
            _car.Add(car);
        }

        public void Delete(Car car)
        {
            Car carDelete = _car.SingleOrDefault(p => p.Id == car.Id);
            _car.Remove(carDelete);
        }
        public void Update(Car car)
        {
            Car carDelete = _car.SingleOrDefault(p => p.Id == car.Id);
            carDelete.BrandId = car.BrandId;
            carDelete.ColorId = car.ColorId;
            carDelete.DailyPrice = car.DailyPrice;
            carDelete.Description = car.Description;
            carDelete.ModelYear = car.ModelYear;
        }

        public List<Car> GetAll()
        {
            return _car;
        }

        public List<Car> GetById(int id)
        {
            return _car.Where(p => p.Id == id).ToList();
        }

        
    }
}
