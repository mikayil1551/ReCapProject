using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.Constants.Messages;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
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
        IBrandService _brandService;
        //private InMemoryCarDal inMemoryCarDal;
        public CarManager(ICarDal carDal,IBrandService brandService)
        {
            _carDal = carDal;
            _brandService = brandService;
        }
        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
            IResult result = BusinessRules.Run(CheckIfCarCountOfBrandCorrect(car.BrandId));
            if (result!=null)
            {
                return result;
            }
            _carDal.Add(car);    
            return new SuccessResult(MessagesCommon.Added);
        }
        private IResult CheckIfCarCountOfBrandCorrect(int brandId)
        {
            if (brandId==1)
            {
                var result = _carDal.GetAll(c => c.BrandId == brandId).Count;
                if (result>=2)
                {
                    return new ErrorResult(CarMessages.CarCountOfTankError);
                }
            }
            return new SuccessResult();
        }
        [ValidationAspect(typeof(CarValidator))]
        public IResult Delete(Car car)
        {
           _carDal.UpdateDelete(car);
           return new SuccessResult(MessagesCommon.Deleted);

        }
        [CacheAspect] //key,value
        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 8)
            {
                return new ErrorDataResult<List<Car>>(MessagesCommon.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(x=>x.IsDelete==false), MessagesCommon.Listed);
        }
        public IDataResult<List<Car>> GetAllBy(int brandId, int colorId)
        {
            return new SuccessDataResult<List<Car>>();
        }
         
        [CacheAspect] 
        [PerformanceAspect(5)]//bu aspect method calisdigin da calisma suresi 5 saniyeden fazla olarsa uyarir

        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == carId));
        }
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), CarMessages.CarDetailsListed);
        }
        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId));
        }
        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == colorId));
        }
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(MessagesCommon.Updated);
        }
        public IResult UpdateDelete(Car car)
        {
            _carDal.UpdateDelete(car);
            return new SuccessResult(MessagesCommon.Deleted);
        }
        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {
            Add(car);
            if (car.DailyPrice > 10)
            {
                throw new Exception("");
            }
            Add(car);
            return null;
        }
    }
}
