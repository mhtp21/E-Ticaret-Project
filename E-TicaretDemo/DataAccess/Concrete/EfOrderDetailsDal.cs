﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class EfOrderDetailsDal : EfEntityRepositoryBase<OrderDetails, TradeDbContext>, IOrderDetailsDal
    {
        public List<OrderDetailsDto> GetOrderDetails(Expression<Func<OrderDetailsDto, bool>> filter = null)
        {
            using (TradeDbContext context = new TradeDbContext())
            {
                var result = from orderDetail in context.OrderDetails
                             join order in context.Orders on orderDetail.OrderId equals order.Id
                             join product in context.Products on orderDetail.ProductId equals product.Id
                             join orderStatus in context.OrderStatuses on order.OrderStatusId equals orderStatus.Id
                             join user in context.Users on order.UserId equals user.Id
                             select new OrderDetailsDto()
                             {
                                 OrderId = order.Id,
                                 ProductId = product.Id,
                                 UserId = user.Id,
                                 ProductName = product.Name,
                                 OrderStatus = orderStatus.Name,
                                 SalePrice = orderDetail.SalePrice,
                                 CreateDate = orderDetail.CreateDate,
                                 Active = orderDetail.Active,
                                 Count = orderDetail.Count,
                                 Images = (from i in context.ProductsImages where i.ProductId == product.Id select i.ImagePath).ToList(),
                             };
                return filter == null ?  result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
