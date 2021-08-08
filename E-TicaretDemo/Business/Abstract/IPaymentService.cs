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
    public interface IPaymentService:ICrudOperationService<Payment>
    {
        IDataResult<int> GetByIdAdd(Payment payment);
        IDataResult<Payment> GetById(int id);
        IDataResult<List<Payment>> GetByCardNumber(string cardNumber);
        IResult IsCardExist(Payment payment);
    }
}
