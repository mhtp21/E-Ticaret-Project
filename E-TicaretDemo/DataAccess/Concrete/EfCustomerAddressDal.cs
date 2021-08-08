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
    public class EfCustomerAddressDal : EfEntityRepositoryBase<CustomerAddress, TradeDbContext>, ICustomerAddressDal
    {
        public List<CustomerAddressDto> GetCustomerAddressesDto(Expression<Func<CustomerAddressDto, bool>> filter = null)
        {
            using (TradeDbContext context = new TradeDbContext())
            {
                var result = from customerAdress in context.CustomerAddresses
                             join user in context.Users on customerAdress.CustomerId equals user.Id
                             join address in context.Addresses on customerAdress.AddressId equals address.Id
                             select new CustomerAddressDto()
                             {
                                 CustomerId = user.Id,
                                 AddressId = address.Id,
                                 CityId = address.CityId,
                                 AddressDetail = address.AddressDetail,
                                 PostalCode = address.PostalCode,
                                 CreateDate = address.CreateDate,
                                 Active = address.Active
                             };
                return filter == null ?  result.ToList() :  result.Where(filter).ToList();
            }
        }
    }
}
