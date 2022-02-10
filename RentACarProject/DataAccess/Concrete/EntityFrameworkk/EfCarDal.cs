using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFrameworkk
{
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            using (DbCarContext context = new DbCarContext())
            {
                var addedContext = context.Entry(entity);
                addedContext.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Car entity)
        {
            using (DbCarContext context = new DbCarContext())
            {
                var deleteContext = context.Entry(entity);
                deleteContext.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (DbCarContext context = new DbCarContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (DbCarContext context = new DbCarContext())
            {
                return filter == null ? context.Set<Car>().ToList() : context.Set<Car>().Where(filter).ToList();
            }
        }

        public void Update(Car entity)
        {
            using (DbCarContext context = new DbCarContext())
            {
                var updateContext = context.Entry(entity);
                updateContext.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
