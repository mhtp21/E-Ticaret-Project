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
    public interface IBrandService : ICrudOperationService<Brand>
    {
        IDataResult<List<BrandDetailDto>> GetBrandDetails();
    }
}
