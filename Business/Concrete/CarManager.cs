using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager: ICarService
    {
        ICarDal _carDal;
        private InMemoryCarDal inMemoryCarDal;
        private InMemoryCarDal inMemoryCarDal1;

        public CarManager()
        {
        }

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public CarManager(InMemoryCarDal inMemoryCarDal)
        {
            this.inMemoryCarDal = inMemoryCarDal;
        }

        public CarManager(InMemoryCarDal inMemoryCarDal)
        {
            this.inMemoryCarDal = inMemoryCarDal;
        }

        public List<Car> GetAll()
        {
            return _carDal.GetALL();
        }

    }
}
