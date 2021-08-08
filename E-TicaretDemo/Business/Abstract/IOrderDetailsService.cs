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
    public interface IOrderDetailsService:ICrudOperationService<OrderDetails>
    {
        IDataResult<List<OrderDetailsDto>> GetAllDetails();
        IDataResult<List<OrderDetailsDto>> GetAllDetailsByUserId(int userId);
        IResult MultiAdd(OrderDetails[] orderDetails);
    }
}
