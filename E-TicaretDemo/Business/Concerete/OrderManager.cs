using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concerete
{
    public class OrderManager : IOrderService
    {
        private IOrderDal _orderDal;
        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }
        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("admin,user")]
        public IResult Add(Order entity)
        {
            _orderDal.Add(entity);
            return new SuccessResult();
        }
        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("admin,user")]
        public IResult Delete(Order entity)
        {
            _orderDal.Delete(entity);
            return new SuccessResult(Messages.DeletedOrder);
        }
        public IDataResult<List<Order>> GetAll()
        {
            return new SuccessDataResult<List<Order>>(_orderDal.GetAll());
        }
        [SecuredOperation("admin,user")]
        public IDataResult<long> GetByIdAdd(Order orders)
        {
            _orderDal.Add(orders);
            return new SuccessDataResult<long>(orders.Id, Messages.AddedOrder);
        }
        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("admin,user")]
        public IResult Update(Order entity)
        {
            _orderDal.Update(entity);
            return new SuccessResult(Messages.UpdatedOrder);
        }
    }
}
