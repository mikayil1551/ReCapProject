using Business.Abstract;
using Business.Concrete;
using Business.Constants;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            #region Comments
            //Lesson8();
            //Lesson9();
            //CarGetAll();
            //BrandGetAll();
            //CarColorGetAll();  
            //CarDelete();
            //BrandDelete();
            //BrandAdd();
            //BrandManager brandManager = new BrandManager(new EfBrandDal());
            //Console.WriteLine("Brand'idinizi giriniz:");
            //Brand brand = new Brand();
            //brandManager.Update(brand);
            //BrandUpdate();
            //UserAdd();
            //CustomerAdd();
            #endregion



            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Console.WriteLine("carId'nizi giriniz");
            int carId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("CustomerId'nizi giriniz");
            int customerId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Kaç gün kiralamak istiyorsunuz?");
            int day = Convert.ToInt32(Console.ReadLine());
            Rental rental = new Rental()
            {

                CarId = carId,
                CustomerId = customerId,
                RentDate = Convert.ToDateTime(DateTime.Now),
                ReturnDate = Convert.ToDateTime(DateTime.Now.AddDays(day))
            };

            var data = rentalManager.Add(rental);
            if (data.Success == true)
            {
                rentalManager.Add(rental);
                Console.WriteLine(data.Message);
            }
            else
            {
                Console.WriteLine(data.Message);
            }

        }
        private static void BrandUpdate()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(String.Format("{0}:{1}", brand.BrandId, brand.BrandName));
            }
            Console.WriteLine("Brand'İd giriniz:");
            int brandId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Brand'isminizi giriniz:");
            string brandName = Console.ReadLine();
            Brand updateBrand = brandManager.GetById(brandId).Data;
            updateBrand.BrandName = brandName;
            brandManager.Update(updateBrand);
        }
        private static void CustomerAdd()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            Console.WriteLine("UserId'nizi giriniz");
            int userId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("CompanyName'nizi giriniz");
            string companyName = Console.ReadLine();
            Customer customer = new Customer()
            {
                UserId = userId,
                CompanyName = companyName
            };
            customerManager.Add(customer);
        }

        private static void UserAdd()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            Console.WriteLine("UserFirstName'nizi giriniz");
            string userFirstName = Console.ReadLine();
            Console.WriteLine("UserLastName'nizi giriniz");
            string userLastName = Console.ReadLine();
            Console.WriteLine("Email'nizi giriniz");
            string userEmail = Console.ReadLine();
            Console.WriteLine("Password'unuzu giriniz");
            string userPassword = Console.ReadLine();
            User user = new User()
            {
                FirstName = userFirstName,
                LastName = userLastName,
                Email = userEmail,
                Password = userPassword
            };
            userManager.Add(user);
        }



        private static void BrandDelete()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Console.WriteLine("Brand'idinizi giriniz:");
            int brandId = Convert.ToInt32(Console.ReadLine());
            Brand brand = new Brand()
            {
                BrandId = brandId
            };
            brandManager.Delete(brand);
        }

        private static void BrandAdd()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Console.WriteLine("Brand'isminizi giriniz:");
            string brandName = Console.ReadLine();
            Brand brand = new Brand()
            {
                BrandName = brandName
            };
            brandManager.Add(brand);
        }

        //private static void CarDelete()
        //{
        //    CarManager carManager = new CarManager(new EfCarDal(), ICarDal carDal, IBrandService brandService);
        //    Console.WriteLine("Car'idinizi giriniz:");
        //    int carId = Convert.ToInt32(Console.ReadLine());
        //    Car car = new Car()
        //    {
        //        CarId = carId
        //    };
        //    carManager.Delete(car);
        //}

        private static void ColorGetAll()
        {
            ColorManager carColorManager = new ColorManager(new EfColorDal());
            foreach (var color in carColorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void BrandGetAll()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        //private static void CarGetAll()
        //{
        //    CarManager carManager = new CarManager(new EfCarDal());
        //    foreach (var car in carManager.GetAll().Data)
        //    {
        //        Console.WriteLine(car.CarName+"/"+car.CarId);
        //    }
        //}

        //private static void Lesson9()
        //{
        //    try
        //    {
        //        CarManager carManager = new CarManager(new EfCarDal());
        //        foreach (var car in carManager.GetCarDetails().Data)
        //        {
        //            Console.WriteLine(car.CarName + "/" + car.BrindName + "/" + car.ColorName + "/" + car.DailyPrice);
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        Console.WriteLine(ex);
        //    }
        //}

        //private static void Lesson8()
        //{
        //    while (true)
        //    {
        //        CarManager carManager = new CarManager(new EfCarDal());
        //        BrandManager brandManager = new BrandManager(new EfBrandDal());
        //        ColorManager colorManager = new ColorManager(new EfColorDal());
        //        Console.WriteLine("Car'inizi giriniz:");
        //        string carName = Console.ReadLine();
        //        Console.WriteLine("GunlukFiyatinizi giriniz:");
        //        decimal dailyPrice = Convert.ToDecimal(Console.ReadLine());
        //        Console.WriteLine("Description'inizi giriniz:");
        //        string description = Console.ReadLine();
        //        foreach (var brand in brandManager.GetAll().Data)
        //        {
        //            Console.WriteLine(String.Format("{0}:{1}", brand.BrandId, brand.BrandName));
        //        }
        //        Console.WriteLine("Brand'inizi giriniz:");
        //        int brandId = Convert.ToInt32(Console.ReadLine());
        //        foreach (var color in colorManager.GetAll().Data)
        //        {
        //            Console.WriteLine(String.Format("{0}:{1}", color.ColorId, color.ColorName));
        //        }
        //        Console.WriteLine("Color'unuzu giriniz:");
        //        int colorId = Convert.ToInt32(Console.ReadLine());
        //        Car car = new Car()
        //        {
        //            CarName = carName,
        //            DailyPrice = dailyPrice,
        //            Description = description,
        //            BrandId = brandId,
        //            ColorId = colorId,
        //            ModelYear = Convert.ToDateTime(DateTime.Now)

        //        };
        //        carManager.Add(car);
        //    }
        //}
        //Console.WriteLine("Renk id'yi giriniz:");
        //int colorId = Convert.ToInt32(Console.ReadLine());
        //Console.WriteLine("Marka id'yi giriniz:");
        //int brandId = Convert.ToInt32(Console.ReadLine());

        //foreach (var car in carManager.GetCarsByColorId(colorId))
        //{
        //    Console.WriteLine(car.CarName);
        //}
        //foreach (var car in carManager.GetCarsByBrandId(brandId))
        //{
        //    Console.WriteLine(car.CarName);
        //}


    }


}
