using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IFavoriteDal : IEntityRepository<Favorite>
    {
        List<FavoriteDetailDto> GetFavoriteDetails(Expression<Func<FavoriteDetailDto, bool>> filter = null);
    }
}
