using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface ICustomerAddressDal : IEntityRepository<CustomerAddress>
    {
        List<CustomerAddressDto> GetCustomerAddressesDto(Expression<Func<CustomerAddressDto, bool>> filter = null);
    }
}
