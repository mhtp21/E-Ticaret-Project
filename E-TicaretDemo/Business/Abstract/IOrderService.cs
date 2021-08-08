using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.BaseOperations;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IOrderService:ICrudOperationService<Order>
    {
        IDataResult<long> GetByIdAdd(Order orders);
    }
}
