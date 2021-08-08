using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Business.BaseOperations;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IBasketService : ICrudOperationService<Basket>
    {
        IDataResult<List<BasketDetailDto>> GetBasketDetails();
        IDataResult<List<BasketDetailDto>> GetBasketDetailsByUserId(int userId);
    }
}
