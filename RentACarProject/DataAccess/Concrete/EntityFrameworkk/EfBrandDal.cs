using Core.DataAccess.EntityFramework;
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
    public class EfBrandDal : EfEntityFrameworkBase<Brand,DbCarContext>,IBrandDal
    {
       
    }
}
