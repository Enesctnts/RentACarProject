using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void Add(Car car)
        {
            if (car.Description.Length>2)
            {
                if (car.DailyPrice > 0)
                {
                    Console.WriteLine("Ürün Eklendi");
                    _carDal.Add(car);
                }
                else
                {
                    Console.WriteLine("Araba günlük fiyat kuralına uymadınız.");
                }
                
            }
            else
            {
                Console.WriteLine("İsim kuralına uyamadınız.");
            }
           
            
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
            Console.WriteLine("Ürün Güncellendi");
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
            Console.WriteLine("Ürün Silindi");
        }

        public Car Get(int id)
        {
            return _carDal.Get(p=>p.Id == id);
        }

        public List<Car> GetAll()
        {
           return _carDal.GetAll();
        }

        
        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(p => p.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(p => p.ColorId == id);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }
    }
}
