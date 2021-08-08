using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;


namespace Business.Concerete
{
    public class CustomerAddressManager : ICustomerAddressService
    {
        private ICustomerAddressDal _customerAddressDal;
        public CustomerAddressManager(ICustomerAddressDal customerAddressDal)
        {
            _customerAddressDal = customerAddressDal;
        }
        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("admin,user")]
        [CacheRemoveAspect("ICustomerAddressService")]
        [ValidationAspect(typeof(CustomerAddressValidator))]
        public IResult Add(CustomerAddress entity)
        {
            _customerAddressDal.Add(entity);
            return new SuccessResult();
        }
        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("admin,user")]
        [CacheRemoveAspect("ICustomerAddressService")]
        public IResult Delete(CustomerAddress entity)
        {
            _customerAddressDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<List<CustomerAddress>> GetAll()
        {
            return new SuccessDataResult<List<CustomerAddress>>(_customerAddressDal.GetAll());
        }

        public IDataResult<List<CustomerAddressDto>> GetAllDatails()
        {
            return new SuccessDataResult<List<CustomerAddressDto>>(_customerAddressDal.GetCustomerAddressesDto());
        }

        public IDataResult<List<CustomerAddress>> GetByCustomerId(int customerId)
        {
            return new SuccessDataResult<List<CustomerAddress>>(_customerAddressDal.GetAll(i => i.CustomerId == customerId));
        }

        public IDataResult<List<CustomerAddressDto>> GetDetailsByAddressId(int addressId)
        {
            return new SuccessDataResult<List<CustomerAddressDto>>(_customerAddressDal.GetCustomerAddressesDto(i => i.AddressId == addressId));
        }

        public IDataResult<List<CustomerAddressDto>> GetDetailsByCustomerId(int customerId)
        {
            return new SuccessDataResult<List<CustomerAddressDto>>(_customerAddressDal.GetCustomerAddressesDto(i => i.CustomerId == customerId));
        }
        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("admin,user")]
        [CacheRemoveAspect("ICustomerAddressService")]
        [ValidationAspect(typeof(CustomerAddressValidator))]
        public IResult Update(CustomerAddress entity)
        {
            _customerAddressDal.Update(entity);
            return new SuccessResult();
        }
    }
}
