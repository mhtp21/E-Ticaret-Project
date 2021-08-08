﻿using System;
using System.Collections.Generic;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class EfBasketDal : EfEntityRepositoryBase<Basket, TradeDbContext>, IBasketDal
    {
        public List<BasketDetailDto> GetBasketDetails(Expression<Func<BasketDetailDto, bool>> filter = null)
        {
            using (TradeDbContext context = new TradeDbContext())
            {
                var result = from basket in context.Baskets
                             join product in context.Products on basket.ProductId equals product.Id
                             join brand in context.Brands on basket.BrandId equals brand.Id
                             join user in context.Users on basket.UserId equals user.Id
                             select new BasketDetailDto
                             {
                                 BasketId = basket.Id,
                                 UserId = user.Id,
                                 ProductId = product.Id,
                                 BrandName = brand.Name,
                                 ProductName = product.Name,
                                 UserFullName = $"{user.FirstName} {user.LastName}",
                                 Price = product.Price,
                                 Images = (from i in context.ProductsImages where i.ProductId == product.Id select i.ImagePath).ToList(),
                                 Count = basket.Count,
                                 CreateDate = basket.CreateDate,
                                 Active = basket.Active
                             };
                return filter == null ?  result.ToList() :  result.Where(filter).ToList();
            }
        }
    }
}
