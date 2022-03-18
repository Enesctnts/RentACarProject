using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFrameworkk
{
    public class EfCustomerDal : EfEntityFrameworkBase<Customer, DbCarContext>, ICustomerDal
    {

        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (DbCarContext context = new DbCarContext())
            {
                var result = from c in context.Customers
                             join u in context.Users 
                             on c.UserId equals u.UserId
                             select new CustomerDetailDto
                             {
                                 CustomerId = c.CustomerId,
                                 UserId = c.UserId,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 CompanyName = c.CompanyName,
                                 Email = u.Email
                             };
                return result.ToList();
            }
        }

    }
}
