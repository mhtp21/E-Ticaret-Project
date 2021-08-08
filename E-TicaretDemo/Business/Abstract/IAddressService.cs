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
    public interface IAddressService:ICrudOperationService<Address>
    {
        IDataResult<long> GetIdAdd(Address address);
        IDataResult<Address> GetById(int id);
        IDataResult<List<Address>> GetAllByUserId(int userId);
        IDataResult<List<Address>> GetAllByCityId(int cityId);
    }
}
