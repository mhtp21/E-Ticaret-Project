﻿using System;
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
    public interface IProductService:ICrudOperationService<Product>
    {
        IDataResult<int> GetByIdAdd(Product product);
        IDataResult<List<ProductDetailDto>> GetProductDetails();
        IDataResult<List<ProductDetailDto>> GetProductDetailsByMinPriceAndMaxPrice(decimal minPrice, decimal maxPrice);
        IDataResult<List<ProductDetailDto>> GetProductDetailsFilterDesc();
        IDataResult<List<ProductDetailDto>> GetProductDetailsFilterAsc();
        IDataResult<List<ProductDetailDto>> GetProductDetailsMeasurement();
        IDataResult<List<ProductDetailDto>> GetProductDetailByCategoryId(int categoryId);
        IDataResult<List<ProductDetailDto>> GetProductDetailByProductId(int productId);
        IDataResult<List<ProductDetailDto>> GetProductDetailByBrandId(int brandId);
        IDataResult<List<ProductDetailDto>> GetLimitedProductDetailsByProduct(int limit);
        IDataResult<List<ProductDetailDto>> GetAllProductDetailsByProductWithPage(int page, int pageSize);
        IDataResult<List<Product>> GetAllByCategory(int categoryId);
    }
}
