using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concerete
{
    public class FavoriteManager : IFavoriteService
    {
        private IFavoriteDal _favoriteDal;
        public FavoriteManager(IFavoriteDal favoriteDal)
        {
            _favoriteDal = favoriteDal;
        }
        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("admin,user")]
        [CacheRemoveAspect("IFavoriteService.Get")]
        public IResult Add(Favorite entity)
        {
            _favoriteDal.Add(entity);
            return new SuccessResult(Messages.FavoriteAdded);
        }
        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("admin,user")]
        [CacheRemoveAspect("IFavoriteService.Get")]
        public IResult Delete(Favorite entity)
        {
            _favoriteDal.Delete(entity);
            return new SuccessResult(Messages.FavoriteDeleted);
        }
        [CacheAspect]
        public IDataResult<List<Favorite>> GetAll()
        {
            return new SuccessDataResult<List<Favorite>>(_favoriteDal.GetAll());
        }
        [CacheAspect]
        public IDataResult<List<FavoriteDetailDto>> GetAllDetails()
        {
            return new SuccessDataResult<List<FavoriteDetailDto>>(_favoriteDal.GetFavoriteDetails());
        }
        [CacheAspect]
        public IDataResult<List<FavoriteDetailDto>> GetAllDetailsByUserId(int userId)
        {
            return new SuccessDataResult<List<FavoriteDetailDto>>(_favoriteDal.GetFavoriteDetails(i => i.UserId == userId));
        }
        [CacheAspect]
        public IDataResult<List<FavoriteDetailDto>> GetAllDetailsFilterAscByUserId(int userId)
        {
            return new SuccessDataResult<List<FavoriteDetailDto>>(_favoriteDal.GetFavoriteDetails(i => i.UserId == userId).OrderBy(i=>i.Price).ToList());
        }
        [CacheAspect]
        public IDataResult<List<FavoriteDetailDto>> GetAllDetailsFilterDescByUserId(int userId)
        {
            return new SuccessDataResult<List<FavoriteDetailDto>>(_favoriteDal.GetFavoriteDetails(i => i.UserId == userId).OrderByDescending(i => i.Price).ToList());
        }
        [CacheRemoveAspect("IFavoriteService.Get")]
        public IDataResult<int> GetByIdAdd(Favorite favorite)
        {
            _favoriteDal.Add(favorite);
            return new SuccessDataResult<int>(favorite.Id, Messages.FavoriteAdded);
        }
        [CacheAspect]
        public IDataResult<List<FavoriteDetailDto>> GetDetailsByUserAndProduct(int userId, int productId)
        {
            return new SuccessDataResult<List<FavoriteDetailDto>>(_favoriteDal.GetFavoriteDetails(i => i.UserId == userId && i.ProductId == productId));
        }
        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("admin,user")]
        [CacheRemoveAspect("IFavoriteService.Get")]
        public IResult Update(Favorite entity)
        {
            _favoriteDal.Update(entity);
            return new SuccessResult(Messages.FavoriteUpdated);
        }
    }
}
