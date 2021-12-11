﻿using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
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

        public void Add(Brand entity)
        {
            throw new NotImplementedException();
        }
        public List<Brand> GetAll()
        {
            return _brandDal.GetALL();
        }

    }
}
