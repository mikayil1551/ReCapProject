using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal:ICarDal
    {
        List<Car> _cars;
        List<Color> _colors;
        List<Brand> _brands;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{CarId=1,BrandId=1,ColorId=1,DailyPrice=500,Description="Hızlı",ModelYear=Convert.ToDateTime("03-Jan-2016")},
                new Car{CarId=2,BrandId=2,ColorId=2,DailyPrice=600,Description="Sport",ModelYear=Convert.ToDateTime("04-Feb-2017")},
                new Car{CarId=3,BrandId=3,ColorId=3,DailyPrice=700,Description="Yavaş",ModelYear=Convert.ToDateTime("05-Dec-2018")},
                new Car{CarId=4,BrandId=4,ColorId=4,DailyPrice=800,Description="Ucuz",ModelYear=Convert.ToDateTime("06-Jul-2019")},
                new Car{CarId=5,BrandId=5,ColorId=5,DailyPrice=900,Description="Pahalı",ModelYear=Convert.ToDateTime("07-Jun-2014")}
            };

            _colors = new List<Color>
            {
                new Color{ColorId=1,ColorName="Beyaz"},
                new Color{ColorId=2,ColorName="Mavi"},
                new Color{ColorId=3,ColorName="Yeşil"},
                new Color{ColorId=4,ColorName="Kırmızı"},
                new Color{ColorId=5,ColorName="Siyah"}
            };
            _brands = new List<Brand>
            {
                new Brand{BrandId=1,BrandName="Tofaş"},
                new Brand{BrandId=2,BrandName="Toyota"},
                new Brand{BrandId=3,BrandName="Mersedes"},
                new Brand{BrandId=4,BrandName="Khazar"},
                new Brand{BrandId=5,BrandName="Hyundai"}
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetALL()
        {
            return _cars;
        }

        public List<Car> GetALL(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAllBy(int brandId, int colorId)
        {
            return _cars.Where(c => c.BrandId == brandId && c.ColorId == colorId).ToList();
        }

        public Car GetById(int carId)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ModelYear = car.ModelYear;
        }
    }
}
