using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
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
        public IResult Add(Car entity)
        {
            if (entity.CarName.Length<=2 && entity.DailyPrice<0)
            {
                return new ErrorResult(Messages.NameInvalid);
            }
            _carDal.Add(entity);    
            return new SuccessResult(Messages.Added);
        } 
        public IResult Delete(Car entity)
        {
            _carDal.Delete(entity);
            return new SuccessResult(Messages.Deleted);
        }
        //public CarManager(InMemoryCarDal inMemoryCarDal)
        //{
        //    this.inMemoryCarDal = inMemoryCarDal;
        //}
        public IDataResult<List<Car>> GetALL()
        {
            if (DateTime.Now.Hour == 13)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetALL(), Messages.Listed);
        }
        public IDataResult<List<Car>> GetAllBy(int brandId, int colorId)
        {
            return new SuccessDataResult<List<Car>>();
        }
        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == carId));
        }
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.CarDetailsListed);
        }
        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetALL(c => c.BrandId == brandId));
        }
        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetALL(p => p.ColorId == colorId));
        }   
    }
}
