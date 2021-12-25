using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        public IResult Add(Rental rental)
        {
            var result = _rentalDal.GetOrderByReturnDate(rental.CarId);
            if (result != null)
            {
                if (result.ReturnDate < DateTime.Now)
                {
                    _rentalDal.Add(rental);
                    return new SuccessResult(Messages.Added);
                }
                else
                {
                    return new ErrorResult(Messages.Rented);
                }
            }
            else
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.Added);
            }
        }
        public IDataResult<Rental> GetById(int rentCarId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(c => c.Id == rentCarId));
        }
        public IResult Delete(Rental rental)
        {
            _rentalDal.UpdateDelete(rental);
            return new SuccessResult(Messages.Deleted);
        }
        public IDataResult<List<Rental>> GetAll()
        {
            if (DateTime.Now.Hour == 18)
            {
                return new ErrorDataResult<List<Rental>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(x => x.IsDelete == false), Messages.Listed);
        }

        public IDataResult<List<Rental>> GetAllById(int rentCarId)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(x => x.CarId == rentCarId), Messages.Listed);
        }
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.Updated);
        }

        public IDataResult<Rental> GetOrderByReturnDate(int carId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.GetOrderByReturnDate(carId));
        }

        public IResult UpdateDelete(Rental rental)
        {
            _rentalDal.UpdateDelete(rental);
            return new SuccessResult(Messages.Deleted);
        }
    }
}
