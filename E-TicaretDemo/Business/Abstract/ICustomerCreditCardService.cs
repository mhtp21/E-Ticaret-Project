using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.BaseOperations;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICustomerCreditCardService : ICrudOperationService<CustomerCreditCard>
    {
        IDataResult<List<CustomerCreditCard>> GetByCustomerId(int customerId);
        IDataResult<List<CustomerPaymentDetailDto>> GetDetailsByCustomerId(int customerId);
    }
}
