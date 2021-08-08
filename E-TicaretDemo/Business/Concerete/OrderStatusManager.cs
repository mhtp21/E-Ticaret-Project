using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concerete
{
    public class OrderStatusManager : IOrderStatusService
    {
        private IOrderStatusDal _orderStatusDal;
        public OrderStatusManager(IOrderStatusDal orderStatusDal)
        {
            _orderStatusDal = orderStatusDal;
        }
        public IResult Add(OrderStatus entity)
        {
            _orderStatusDal.Add(entity);
            return new SuccessResult();
        }
        public IResult Delete(OrderStatus entity)
        {
            _orderStatusDal.Delete(entity);
            return new SuccessResult();
        }
        public IDataResult<List<OrderStatus>> GetAll()
        {
            return new SuccessDataResult<List<OrderStatus>>(_orderStatusDal.GetAll());
        }
        public IResult Update(OrderStatus entity)
        {
            _orderStatusDal.Update(entity);
            return new SuccessResult();
        }
    }
}