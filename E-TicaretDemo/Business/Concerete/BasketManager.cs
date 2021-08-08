using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concerete
{
    public class BasketManager : IBasketService
    {
        private IBasketDal _basketDal;
        public BasketManager(IBasketDal basketDal)
        {
            _basketDal = basketDal;
        }

        public IResult Add(Basket entity)
        {
            _basketDal.Add(entity);
            return new SuccessResult(Messages.AddedBasket);
        }

        public IResult Delete(Basket entity)
        {
            _basketDal.Delete(entity);
            return new SuccessResult(Messages.DeletedBasket);
        }

        public IDataResult<List<Basket>> GetAll()
        {
            return new SuccessDataResult<List<Basket>>(_basketDal.GetAll());
        }

        public IDataResult<List<BasketDetailDto>> GetBasketDetails()
        {
            return new SuccessDataResult<List<BasketDetailDto>>(_basketDal.GetBasketDetails());
        }

        public IDataResult<List<BasketDetailDto>> GetBasketDetailsByUserId(int userId)
        {
            return new SuccessDataResult<List<BasketDetailDto>>(_basketDal.GetBasketDetails(i => i.UserId == userId));
        }
        [CacheRemoveAspect("IBasketService.Get")]
        public IResult Update(Basket entity)
        {
            _basketDal.Update(entity);
            return new SuccessResult(Messages.UpdatedBasket);
        }
    }
}
