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
    public class EfCustomerCreditCardDal : EfEntityRepositoryBase<CustomerCreditCard, TradeDbContext>, ICustomerCreditCardDal
    {
        public List<CustomerPaymentDetailDto> GetDetails(Expression<Func<CustomerPaymentDetailDto, bool>> filter = null)
        {
            using (TradeDbContext context = new TradeDbContext())
            {
                var result = from customerCreditCard in context.CustomerCreditCards
                             join payment in context.Payments on customerCreditCard.CardId equals payment.Id
                             join user in context.Users on customerCreditCard.CustomerId equals user.Id
                             select new CustomerPaymentDetailDto()
                             {
                                 CardId = customerCreditCard.CardId,
                                 UserId = user.Id,
                                 NameOnTheCard = payment.NameOnTheCard,
                                 CardCvv = payment.CardCvv,
                                 CardNumber = payment.CardNumber,
                                 ExpirationDate = payment.ExpirationDate
                             };
                return filter == null ?  result.ToList() :  result.Where(filter).ToList();
            }
        }
    }
}
