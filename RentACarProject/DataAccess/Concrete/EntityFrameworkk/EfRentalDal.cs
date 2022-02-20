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
    public class EfRentalDal : EfEntityFrameworkBase<Rental, DbCarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetCarRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (DbCarContext context = new DbCarContext())
            {
                var result = from r in filter == null ? context.Rentals : context.Rentals.Where(filter)
                                         join c in context.Cars on r.CarId equals c.Id
                                         join m in context.Customers on r.CustomerId equals m.CustomerId
                                         join u in context.Users on m.UserId equals u.UserId
                                         join b in context.Brands on c.BrandId equals b.BrandId
                                         join n in context.Colors on c.ColorId equals n.ColorId
                                         select new RentalDetailDto
                                         {
                                             RentalId = r.Id,
                                             CarId = c.Id,
                                             BrandName = b.BrandName,
                                             Color = n.ColorName,
                                             ModelYear = c.ModelYear,
                                             DailyPrice = c.DailyPrice,
                                             Description = c.Description,
                                             CustomerId = m.CustomerId,
                                             CustomerFirstName = u.FirstName,
                                             CustomerLastName = u.LastName,
                                             CompanyName = m.CompanyName,
                                             Email = u.Email,
                                             RentDate = r.RentDate,
                                             ReturnDate = r.ReturnDate
                                         };
                return result.ToList();

            }
        }

    }
}
