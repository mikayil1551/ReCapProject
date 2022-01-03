using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;   
        }

        public IResult Add(Brand brand)
        {
            _brandDal.Add(brand);
            return new SuccessResult(MessagesCommon.Added);
        }
        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(x => x.IsDelete == false), MessagesCommon.Listed);
        }
        public IDataResult<List<Brand>> GetAllById(int brandId)
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(x=>x.BrandId==brandId));
        }
        public IDataResult<Brand> GetById(int brandId)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(c => c.BrandId == brandId));
        }
        public IResult Delete(Brand brand)
        {
            _brandDal.UpdateDelete(brand);
            return new SuccessResult(MessagesCommon.Deleted);
        }
        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult(MessagesCommon.Updated);
        }

        public IResult UpdateDelete(Brand brand)
        {
            _brandDal.UpdateDelete(brand);
            return new SuccessResult(MessagesCommon.Deleted);
        }
    }
}
