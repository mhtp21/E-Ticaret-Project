using System;
using System.Collections.Generic;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using System.Linq;
using System.Linq.Expressions;
using Entities.DTOs;
using Entities.Concrete;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfUserDal : EfEntityRepositoryBase<User, TradeDbContext>, IUserDal
    {
        public List<UserDetailDto> GetUserDetails(Expression<Func<UserDetailDto, bool>> filter = null)
        {
            using (var context = new TradeDbContext())
            {
                var result = from user in context.Users
                             select new UserDetailDto
                             {
                                 UserId = user.Id,
                                 FullName = $"{user.FirstName} {user.LastName}"
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }

        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new TradeDbContext())
            {
                var result = from OperationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims on OperationClaim.Id equals userOperationClaim.OperationClaimId
                             select new OperationClaim
                             {
                                 Id = OperationClaim.Id,
                                 Name = OperationClaim.Name
                             };
                return result.ToList();
            }
        }
    }
}