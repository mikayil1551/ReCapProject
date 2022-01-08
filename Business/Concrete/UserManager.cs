using Business.Abstract;
using Core.Entities.Concrete;
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
        public void Add(Core.Entities.Concrete.User user)
        {
            _userDal.Add(user);
        }

        public Core.Entities.Concrete.User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }

        public List<OperationClaim> GetClaims(Core.Entities.Concrete.User user)
        {
            return _userDal.GetClaims(user);
        }
    }
}
