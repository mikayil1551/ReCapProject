using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
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
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {  
            _carDal.Add(car);    
            return new SuccessResult(Messages.Added);
        }
        [ValidationAspect(typeof(CarValidator))]
        public IResult Delete(Car car)
        {
           _carDal.UpdateDelete(car);
           return new SuccessResult(Messages.Deleted);

        }
        //public CarManager(InMemoryCarDal inMemoryCarDal)
        //{
        //    this.inMemoryCarDal = inMemoryCarDal;
        //}
        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 12)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(x=>x.IsDelete==false), Messages.Listed);
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
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId));
        }
        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == colorId));
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.Updated);
        }
        public IResult UpdateDelete(Car car)
        {
            _carDal.UpdateDelete(car);
            return new SuccessResult(Messages.Deleted);
        }
    }
}
