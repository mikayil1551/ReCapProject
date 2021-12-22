﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public IResult Add(User entity)
        {
            _userDal.Add(entity);
            return new SuccessResult(Messages.Added);
        }
        public IResult Delete(User entity)
        {
            _userDal.Delete(entity);
            return new SuccessResult(Messages.Deleted);
        }
        public IDataResult<List<User>> GetALL()
        {
            if (DateTime.Now.Hour == 18)
            {
                return new ErrorDataResult<List<User>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<User>>(_userDal.GetALL(), Messages.Listed);
        }
        public IResult Update(User entity)
        {
            _userDal.Update(entity);
            return new SuccessResult(Messages.Updated);
        }
    }
}