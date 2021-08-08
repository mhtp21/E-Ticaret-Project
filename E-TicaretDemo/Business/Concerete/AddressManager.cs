using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concerete
{
    public class AddressManager : IAddressService
    {
        private IAddressDal _addressDal;

        public AddressManager(IAddressDal addressDal)
        {
            _addressDal = addressDal;
        }
        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("admin,user")]
        [CacheRemoveAspect("IAddressService.Get")]
        [ValidationAspect(typeof(AddressValidator))]
        public IResult Add(Address entity)
        {
            _addressDal.Add(entity);
            return new SuccessResult();
        }
        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("admin,user")]
        [CacheRemoveAspect("IAddressService.Get")]
        public IResult Delete(Address entity)
        {
            _addressDal.Delete(entity);
            return new SuccessResult();
        }
        [CacheAspect]
        public IDataResult<List<Address>> GetAll()
        {
            return new SuccessDataResult<List<Address>>(_addressDal.GetAll());
        }
        [CacheAspect]
        public IDataResult<List<Address>> GetAllByCityId(int cityId)
        {
            return new SuccessDataResult<List<Address>>(_addressDal.GetAll(i => i.CityId == cityId));
        }
        [CacheAspect]
        public IDataResult<List<Address>> GetAllByUserId(int userId)
        {
            return new SuccessDataResult<List<Address>>(_addressDal.GetAll(i => i.UserId == userId));
        }
        [CacheAspect]
        public IDataResult<Address> GetById(int id)
        {
            return new SuccessDataResult<Address>(_addressDal.Get(i => i.Id == id));
        }
        [SecuredOperation("admin,user")]
        [CacheRemoveAspect("IAddressService.Get")]
        [ValidationAspect(typeof(AddressValidator))]
        public IDataResult<long> GetIdAdd(Address address)
        {
            _addressDal.Add(address);
            return new SuccessDataResult<long>(address.Id);
        }
        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("admin,user")]
        [CacheRemoveAspect("IAddressService.Get")]
        [ValidationAspect(typeof(AddressValidator))]
        public IResult Update(Address entity)
        {
            _addressDal.Update(entity);
            return new SuccessResult(Messages.AddressUpdated);
        }
    }
}