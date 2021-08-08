using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;



namespace Business.BaseOperations
{
    public interface IImageOperationService<T>
    {
        IResult Add(IFormFile file, ProductsImage productsImage);
        IResult Update(IFormFile file, ProductsImage productsImage);
        IResult Delete(ProductsImage productsImage);
        IDataResult<List<ProductsImage>> GetAll(Expression<Func<ProductsImage, bool>> filter = null);
        IDataResult<ProductsImage> GetById(int id);
    }
}
