using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.BaseOperations;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface IProductImagesService:IImageOperationService<ProductsImage>
    {
        IDataResult<List<ProductsImage>> GetAllByProductId(int id);
        IResult DeleteById(int id);
    }
}
