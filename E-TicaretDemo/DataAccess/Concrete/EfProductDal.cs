using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete
{
    public class EfProductDal : EfEntityRepositoryBase<Product, TradeDbContext>, IProductDal
    {
        public List<ProductDetailDto> GetProductDetails(Expression<Func<ProductDetailDto, bool>> filter = null)
        {
            using (TradeDbContext context = new TradeDbContext())
            {
                var result = from product in context.Products
                             join category in context.Categories on product.CategoryId equals category.CategoryId
                             join brand in context.Brands on product.BrandId equals brand.Id
                             select new ProductDetailDto
                             {
                                 Id = product.Id,
                                 BrandId = brand.Id,
                                 CategoryId = category.CategoryId,
                                 CategoryName = category.Name,
                                 BrandName = brand.Name,
                                 ProductName = product.Name,
                                 Description = product.Description,
                                 Code = product.Code,
                                 Rating = product.Rating,
                                 DiscountRate = product.DiscountRate,
                                 Price = product.Price,
                                 CreateDate = product.CreateDate,
                                 Active = product.Active,
                                 Image = (from image in context.ProductsImages where image.ProductId == product.Id select image).ToList(),
                               

                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
