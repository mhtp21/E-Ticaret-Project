using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class EfBrandDal : EfEntityRepositoryBase<Brand, TradeDbContext>, IBrandDal
    {
        public List<BrandDetailDto> GetBrandsDetails(Expression<Func<BrandDetailDto, bool>> filter = null)
        {
            using (TradeDbContext context = new TradeDbContext())
            {
                var result = from brand in context.Brands
                             select new BrandDetailDto
                             {
                                 BrandId = brand.Id,
                                 BrandName = brand.Name
                             };
                return filter == null ?  result.ToList() :  result.Where(filter).ToList();
            }
        }
    }
}
