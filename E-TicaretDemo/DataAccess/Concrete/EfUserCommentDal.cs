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

namespace DataAccess.Concrete
{
    public class EfUserCommentDal : EfEntityRepositoryBase<UserComment, TradeDbContext>, IUserCommentDal
    {
    }
}
