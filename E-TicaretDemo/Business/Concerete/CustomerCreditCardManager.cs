using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concerete
{
    public class CustomerCreditCardManager : ICustomerCreditCardService
    {
        private ICustomerCreditCardDal _customerCreditCardDal;
        public CustomerCreditCardManager(ICustomerCreditCardDal customerCreditCardDal)
        {
            _customerCreditCardDal = customerCreditCardDal;
        }
        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("admin,user")]
        [ValidationAspect(typeof(CustomerCreditCardValidator))]
        public IResult Add(CustomerCreditCard entity)
        {
            _customerCreditCardDal.Add(entity);
            return new SuccessResult();
        }
        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("admin,user")]
        public IResult Delete(CustomerCreditCard entity)
        {
            _customerCreditCardDal.Delete(entity);
            return new SuccessResult(Messages.DeletedCustomerCreditCard);
        }

        public IDataResult<List<CustomerCreditCard>> GetAll()
        {
            return new SuccessDataResult<List<CustomerCreditCard>>(_customerCreditCardDal.GetAll());
        }

        public IDataResult<List<CustomerCreditCard>> GetByCustomerId(int customerId)
        {
            return new SuccessDataResult<List<CustomerCreditCard>>(_customerCreditCardDal.GetAll(i => i.CustomerId == customerId));
        }

        public IDataResult<List<CustomerPaymentDetailDto>> GetDetailsByCustomerId(int customerId)
        {
            return new SuccessDataResult<List<CustomerPaymentDetailDto>>(_customerCreditCardDal.GetDetails(i => i.UserId == customerId));
        }
        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("admin,user")]
        [ValidationAspect(typeof(CustomerCreditCardValidator))]
        public IResult Update(CustomerCreditCard entity)
        {
            _customerCreditCardDal.Update(entity);
            return new SuccessResult();
        }
    }
}
