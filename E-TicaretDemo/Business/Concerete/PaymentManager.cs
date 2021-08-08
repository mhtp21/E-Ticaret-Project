using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concerete
{
    public class PaymentManager : IPaymentService
    {
        private IPaymentDal _paymentDal;
        public PaymentManager(IPaymentDal paymentDal)
        {
            _paymentDal = paymentDal;
        }
        [SecuredOperation("admin,user")]
        [ValidationAspect(typeof(PaymentValidator))]
        public IResult Add(Payment entity)
        {
            _paymentDal.Add(entity);
            return new SuccessResult();
        }

        public IResult Delete(Payment entity)
        {
            _paymentDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<List<Payment>> GetAll()
        {
            return new SuccessDataResult<List<Payment>>(_paymentDal.GetAll());
        }

        public IDataResult<List<Payment>> GetByCardNumber(string cardNumber)
        {
            return new SuccessDataResult<List<Payment>>(_paymentDal.GetAll(i => i.CardNumber == cardNumber));
        }

        public IDataResult<Payment> GetById(int id)
        {
            throw new NotImplementedException();
        }
        [SecuredOperation("admin,user")]
        [ValidationAspect(typeof(PaymentValidator))]
        public IDataResult<int> GetByIdAdd(Payment payment)
        {
            _paymentDal.Add(payment);
            return new SuccessDataResult<int>(payment.Id, Messages.PaymentAdded);
        }

        public IResult IsCardExist(Payment payment)
        {
            var result = _paymentDal.Get(i =>
            i.NameOnTheCard == payment.NameOnTheCard && i.CardNumber == payment.CardNumber && i.CardCvv == payment.CardCvv);
            if (result == null)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        [ValidationAspect(typeof(PaymentValidator))]
        public IResult Update(Payment entity)
        {
            _paymentDal.Update(entity);
            return new SuccessResult();
        }
    }
}