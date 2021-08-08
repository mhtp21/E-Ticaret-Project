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
    public interface ICustomerAddressService:ICrudOperationService<CustomerAddress>
    {

        IDataResult<List<CustomerAddress>> GetByCustomerId(int customerId);
        IDataResult<List<CustomerAddressDto>> GetAllDatails();
        IDataResult<List<CustomerAddressDto>> GetDetailsByCustomerId(int customerId);
        IDataResult<List<CustomerAddressDto>> GetDetailsByAddressId(int addressId);
    }
}
