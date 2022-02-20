using Core.Utilities.Result;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IResult Add(Customer customer);
        IResult Delete(Customer customer);
        IResult Update(Customer customer);
        IDataResult<Customer> Get(int id);
        IDataResult<List<Customer>> GetAll();
        IDataResult<List<Customer>> GetCustomersByCustomerId(int id);
        IDataResult<List<Customer>> GetCustomersByUserId(int id);
        IDataResult<Customer> GetCustomerById(int id);
        IDataResult<List<CustomerDetailDto>> GetCustomerDetails();



    }
}
