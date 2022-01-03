using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }
        public IResult Add(Customer customer)
        {
            if (customer.CompanyName.Length <= 2)
            {
                return new ErrorResult(MessagesCommon.NameInvalid);
            }
            _customerDal.Add(customer);
            return new SuccessResult(MessagesCommon.Added);
        }
        public IResult Delete(Customer customer)
        {
            _customerDal.UpdateDelete(customer);
            return new SuccessResult(MessagesCommon.Deleted);
        }
        public IDataResult<List<Customer>> GetAll()
        {
            if (DateTime.Now.Hour == 18)
            {
                return new ErrorDataResult<List<Customer>>(MessagesCommon.MaintenanceTime);
            }
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(x => x.IsDelete == false), MessagesCommon.Listed);
        }

        public IDataResult<Customer> GetById(int customerId)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c => c.CustomerId == customerId));
        }

        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(MessagesCommon.Updated);
        }

        public IResult UpdateDelete(Customer customer)
        {
            _customerDal.UpdateDelete(customer);
            return new SuccessResult(MessagesCommon.Deleted);
        }
    }
}
