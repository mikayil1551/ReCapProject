using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapContext>, IRentalDal
    {
        public Rental GetOrderByReturnDate(int carId)
        {
            using (ReCapContext context =new ReCapContext())
            {
                return context.Set<Rental>().OrderByDescending(x=>x.ReturnDate).FirstOrDefault(x => x.CarId == carId); ;
            }
        }
    }
}
