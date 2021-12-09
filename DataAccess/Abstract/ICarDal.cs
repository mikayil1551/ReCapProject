using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal
    {
        List<Car> GetALL();
        void Add(Car car);
        void Delete(Car car);
        void Update(Car car);
        List<Car> GetAllBy(int brandId,int colorId);
      
    }
}
