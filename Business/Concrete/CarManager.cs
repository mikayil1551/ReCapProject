using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        //private InMemoryCarDal inMemoryCarDal;



        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car entity)
        {
            if (entity.CarName.Length>=2 && entity.DailyPrice>0)
            {
                _carDal.Add(entity);
            }
            else
            {
                Console.WriteLine("Bilgiler dogru girilmemisdir!");
            }
            
        }

        //public CarManager(InMemoryCarDal inMemoryCarDal)
        //{
        //    this.inMemoryCarDal = inMemoryCarDal;
        //}


        public List<Car> GetAll()
        {
            return _carDal.GetALL();
        }

        public Car GetById(int carId)
        {
            return _carDal.GetById(carId);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _carDal.GetCarsByBrandId(brandId);
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _carDal.GetCarsByColorId(colorId);
        }

       
       
    }
}
