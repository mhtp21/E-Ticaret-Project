using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IOrderDetailsDal : IEntityRepository<OrderDetails>
    {
        List<OrderDetailsDto> GetOrderDetails(Expression<Func<OrderDetailsDto, bool>> filter = null);
    }
}
