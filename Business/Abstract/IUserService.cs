using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(Core.Entities.Concrete.User user);
        void Add(Core.Entities.Concrete.User user);
        Core.Entities.Concrete.User GetByMail(string email);
    }
}
