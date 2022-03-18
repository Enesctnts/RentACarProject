using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFrameworkk
{
    public class EfUserDal : EfEntityFrameworkBase<User, DbCarContext>, IUserDal
    {
        
    }
}
