using Business.Abstract;
using Business.Concrete;
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
            //Lesson8();
            try
            {
                CarManager carManager = new CarManager(new EfCarDal());
                foreach (var car in carManager.GetCarDetails())
                {
                    Console.WriteLine(car.CarName + "/" + car.BrindName + "/" + car.ColorName + "/" + car.DailyPrice);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }
           
        }

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
        //        foreach (var brand in brandManager.GetAll())
        //        {
        //            Console.WriteLine(String.Format("{0}:{1}", brand.BrandId, brand.BrandName));
        //        }
        //        Console.WriteLine("Brand'inizi giriniz:");
        //        int brandId = Convert.ToInt32(Console.ReadLine());
        //        foreach (var color in colorManager.GetAll())
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
