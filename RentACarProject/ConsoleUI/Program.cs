using Business.Concrete;
using Business.Constants;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFrameworkk;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CustomerAdded();
            //BrandAdded();
            //ColorAdded();
            //UserAdded();
            //UserUpdated();
            //CarAdded();
            //RentalAdded();
            //RentalAllUpdate();
            //RentalList();
            //UserListDetail();
            //GetAllByColor();
            //GetAllByBrand();
            //GetAllByCar();
           


        }

        private static void UserUpdated()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            Console.WriteLine(userManager.Update(new User { UserId = 4, FirstName = "ENES", LastName = "ÇETİNTAŞ", Email = "enesctnts@gmail.com"}).Message);
            Console.WriteLine(userManager.Update(new User { UserId = 5, FirstName = "UGUR", LastName = "ÖNSAL", Email = "ugrons@gmail.com"}).Message);
            Console.WriteLine(userManager.Update(new User { UserId = 6, FirstName = "VOLKAN", LastName = "DEMİREL", Email = "demirelvolkan@gmail.com" }).Message);
            Console.WriteLine(userManager.Update(new User { UserId = 7, FirstName = "ARDA", LastName = "TURAN", Email = "aTuran@gmail.com" }).Message);
        }
        private static void RentalAdded()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            //Rental rental = new Rental { CarId = 2, CustomerId = 2, RentDate = DateTime.Now };
            //rentalManager.Add(rental);
            //Console.WriteLine(rentalManager.Add(rental).Message);

            //Rental rental1 = new Rental { CarId = 3, CustomerId = 1, RentDate = DateTime.Now, ReturnDate = new DateTime(2022,02,21) };
            //rentalManager.Add(rental1);
            //Console.WriteLine(rentalManager.Add(rental1).Message);

            //Rental rental2 = new Rental { CarId = 4, CustomerId = 3, RentDate = DateTime.Now, ReturnDate = new DateTime(2022, 02, 20) };
            //rentalManager.Add(rental2);
            //Console.WriteLine(Messages.RentalAdded);

            Rental rental3 = new Rental { CarId = 3, CustomerId = 6, RentDate = DateTime.Now, ReturnDate = new DateTime(2022,02,21) };
            rentalManager.Add(rental3);
            Console.WriteLine(rentalManager.Add(rental3).Message);


        }
        private static void UserAdded()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            User user1 = new User { FirstName = "Ezgi", LastName = "Yücel", Email = "ezgiyucel@xmail.com"};
            userManager.Add(user1);

            User user2 = new User { FirstName = "ENES", LastName = "ÇETİNTAŞ", Email = "ezgiyucel@xmail.com"};
            userManager.Add(user2);

            User user3 = new User { FirstName = "UGUR", LastName = "ÖNSAL", Email = "ezgiyucel@xmail.com"};
            userManager.Add(user3);

            User user4 = new User { FirstName = "VOLKAN", LastName = "DEMİREL", Email = "ezgiyucel@xmail.com" };
            userManager.Add(user4);

            User user5 = new User { FirstName = "ARDA", LastName = "TURAN", Email = "ezgiyucel@xmail.com" };
            userManager.Add(user5);
        }
        private static void CustomerAdded()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            Customer customer1 = new Customer { UserId = 2, CompanyName = "Ezgi Lojistik" };
            customerManager.Add(customer1);
            Console.WriteLine(Messages.CustomerAdded);

            Customer customer2 = new Customer { UserId = 3, CompanyName = "BIM Lojistik" };
            customerManager.Add(customer2);
            Console.WriteLine(Messages.CustomerAdded);

            Customer customer3 = new Customer { UserId = 4, CompanyName = "ŞOK Lojistik" };
            customerManager.Add(customer3);
            Console.WriteLine(Messages.CustomerAdded);


            Customer customer4 = new Customer { UserId = 5, CompanyName = "A101 Lojistik" };
            customerManager.Add(customer4);
            Console.WriteLine(Messages.CustomerAdded);
        }
        private static void BrandAdded()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            //Brand brand1 = new Brand { BrandName = "JEEP" };
            //brandManager.Add(brand1);
            //Brand brand2 = new Brand { BrandName = "RENAULT" };
            //brandManager.Add(brand2);

            Brand brand3 = new Brand { BrandName = "Volvo" };
            brandManager.Add(brand3);
        }
        private static void ColorAdded()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            //Color color1 = new Color { ColorName = "YEŞİL" };
            //colorManager.Add(color1);
            //Color color2 = new Color {  ColorName = "SİYAH" };
            //colorManager.Add(color2);

            colorManager.Add(new Color { ColorName = "Gri" });
        }
        private static void CarAdded()
        {
            new CarManager(new EfCarDal());

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
        }
        private static void RentalAllUpdate()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Console.WriteLine(rentalManager.Update(new Rental { Id = 1, CarId = 2, CustomerId = 2, RentDate = DateTime.Now, ReturnDate = DateTime.Now.AddDays(1) }).Message);
        }
        private static void GetAllByCar()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine("Marka   : " + car.BrandName);
                Console.WriteLine("Açıklama: " + car.CarName);
                Console.WriteLine("Renk    : " + car.ColorName);
                Console.WriteLine("G.Fiyat : " + car.DailyPrice);
                Console.WriteLine();

            }
        }
        private static void RentalList()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            Console.WriteLine("-----------------------------Kiralama Detay listesi-----------------------------");


            foreach (var rental in rentalManager.GetCarRentalDetails().Data)
            {
                Console.WriteLine("Kiralama Id: {0}, Araç Id: {1} Marka: {2}, Model Yılı: {3}, Araç Rengi:{4}, Günlük Fiyat: {5}, Araç Tanımı: {6} ,Müşteri Id: {7}, Müşteri Adı: {8}, Müşteri Soydı:{9}, Şirket Adı: {10},Müşteri Email: {11}, Kiralama Tarihi Id: {12}, Teslim Tarihi {13}", rental.RentalId, rental.CarId, rental.BrandName, rental.Color, rental.ModelYear, rental.DailyPrice, rental.Description, rental.CustomerId, rental.CustomerFirstName, rental.CustomerLastName, rental.CompanyName, rental.Email, rental.RentDate, rental.ReturnDate);
            }


            Console.WriteLine("-----------------------------Kiralama listesi-----------------------------");

            foreach (var rental in rentalManager.GetAll().Data)
            {
                Console.WriteLine("Kiralama Id: {0}, Araç Id: {1} Müşterin Id: {2}, Kiralama Tarihi: {3}, Araç Teslim Tarihi: {4}", rental.Id, rental.CarId, rental.CustomerId, rental.RentDate, rental.ReturnDate);
            }

        }
        private static void UserListDetail()
        {
            Console.WriteLine("-----------------------------Kullanıcı detay listesi-----------------------------");
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            foreach (var customer in customerManager.GetCustomerDetails().Data)
            {
                Console.WriteLine("Müşteri Id: {0}, Müşteri Kullanıcı Id No: {1}, Müşteri Adı: {2}, Müşteri Soyadı: {3}, Şirket Adı: {4}, Email: {5}, Şifre: {6}", customer.CustomerId, customer.UserId, customer.FirstName, customer.LastName, customer.CompanyName, customer.Email, customer.Password);
            }

            Console.WriteLine("-----------------------------Kullanıcı listesi-----------------------------");

            UserManager userManager = new UserManager(new EfUserDal());
            foreach (var user in userManager.GetAll().Data)
            {

                Console.WriteLine("Kullanıcı Id: {0}, Kıllanıcı Adı: {1}, Kullanıcı Soyadı: {2}, Email: {3}", user.UserId, user.FirstName, user.LastName, user.Email);
            }

        }
        private static void GetAllByBrand()
        {
            Console.WriteLine("------------------------------Veri tabanındaki tüm markalar------------------------------");

            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine("Marka: {0} | Renk: {1}  | Araba Adı: {2} | Günlük Fiyat: {3}  | Tanımlama: {4}", car.BrandName, car.ColorName, car.CarName, car.DailyPrice);
            }
        }

        private static void GetAllByColor()
        {
            Console.WriteLine("------------------------------Veri tabanındaki tüm renkler------------------------------");

            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(" Renk ID: {0}, Renk Adı: {1}", color.ColorId, color.ColorName);
            }
        }
    }
}
