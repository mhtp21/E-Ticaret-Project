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
    public class OrderDetailsManager : IOrderDetailsService
    {
        private IOrderDetailsDal _orderDetailsDal;
        public OrderDetailsManager(IOrderDetailsDal orderDetailsDal)
        {
            _orderDetailsDal = orderDetailsDal;
        }

        public IResult Add(OrderDetails entity)
        {
            _orderDetailsDal.Add(entity);
            return new SuccessResult();
        }

        public IResult Delete(OrderDetails entity)
        {
            _orderDetailsDal.Delete(entity);
            return new SuccessResult();
        }
        [CacheAspect]
        public IDataResult<List<OrderDetails>> GetAll()
        {
            return new SuccessDataResult<List<OrderDetails>>(_orderDetailsDal.GetAll());
        }
        [CacheAspect]
        public IDataResult<List<OrderDetailsDto>> GetAllDetails()
        {
            return new SuccessDataResult<List<OrderDetailsDto>>(_orderDetailsDal.GetOrderDetails());
        }

        public IDataResult<List<OrderDetailsDto>> GetAllDetailsByUserId(int userId)
        {
            return new SuccessDataResult<List<OrderDetailsDto>>(_orderDetailsDal.GetOrderDetails(i => i.UserId == userId));
        }
        [LogAspect(typeof(FileLogger))]
        [ValidationAspect(typeof(OrderDetailsValidator))]
        public IResult MultiAdd(OrderDetails[] orderDetails)
        {
            _orderDetailsDal.MultiAdd(orderDetails);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(OrderDetailsValidator))]
        public IResult Update(OrderDetails entity)
        {
            _orderDetailsDal.Update(entity);
            return new SuccessResult();
        }
    }
}