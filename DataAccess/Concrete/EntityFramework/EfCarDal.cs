using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car,ReCapContext>,ICarDal
    {
        public Car GetById(int carId)
        {
            using (ReCapContext context = new ReCapContext())
            {
                return context.Set<Car>().FirstOrDefault(x => x.CarId == carId);
            }
         
        }
        public List<Car> GetCarsByBrandId(int brandId)
        {
            using (ReCapContext context = new ReCapContext())
            {
                return context.Set<Car>().Where(x => x.BrandId == brandId).ToList();
            }
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            using (ReCapContext context = new ReCapContext())
            {
                return context.Set<Car>().Where(x => x.ColorId == colorId).ToList();
            }
        }

        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from ca in context.Cars
                             join co in context.Colors
                             on ca.ColorId equals co.ColorId
                             join br in context.Brands
                             on ca.BrandId equals br.BrandId
                             select new CarDetailDto
                             {
                                 CarName = ca.CarName,
                                 BrindName = br.BrandName,
                                 ColorName = co.ColorName,
                                 DailyPrice = ca.DailyPrice
                             };
                return result.ToList();
            }
        }
    }
}
