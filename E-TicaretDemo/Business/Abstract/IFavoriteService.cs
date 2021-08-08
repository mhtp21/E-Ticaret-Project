using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.BaseOperations;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;


namespace Business.Abstract
{
    public interface IFavoriteService:ICrudOperationService<Favorite>
    {
        IDataResult<List<FavoriteDetailDto>> GetAllDetails();
        IDataResult<List<FavoriteDetailDto>> GetDetailsByUserAndProduct(int userId, int productId);
        IDataResult<List<FavoriteDetailDto>> GetAllDetailsByUserId(int userId);
        IDataResult<List<FavoriteDetailDto>> GetAllDetailsFilterAscByUserId(int userId);
        IDataResult<List<FavoriteDetailDto>> GetAllDetailsFilterDescByUserId(int userId);
        IDataResult<int> GetByIdAdd(Favorite favorite);
    }
}
