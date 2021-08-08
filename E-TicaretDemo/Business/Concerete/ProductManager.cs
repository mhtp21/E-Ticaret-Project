using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concerete
{
    public class ProductManager: IProductService
    {
        private IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        [LogAspect(typeof(DatabaseLogger))]
        [SecuredOperation("admin,product.add")]
        [CacheRemoveAspect("IProductService.Get")]
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product entity)
        {
            _productDal.Add(entity);
            return new SuccessResult(Messages.ProductAdded);
        }
        [LogAspect(typeof(DatabaseLogger))]
        [SecuredOperation("admin")]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Delete(Product entity)
        {
            _productDal.Delete(entity);
            return new SuccessResult(Messages.ProductDeleted);
        }
        [LogAspect(typeof(FileLogger))]
        [CacheAspect]
        public IDataResult<List<Product>> GetAll()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll());
        }
        [CacheAspect]
        public IDataResult<List<Product>> GetAllByCategory(int categoryId)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(i => i.CategoryId == categoryId),"Ürünler kategoriye göre filtrelendi");
        }

        public IDataResult<List<ProductDetailDto>> GetAllProductDetailsByProductWithPage(int page, int pageSize)
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails().Skip((page - 1) * pageSize).Take(pageSize).ToList());
        }

        public IDataResult<int> GetByIdAdd(Product product)
        {
            _productDal.Add(product);
            return new SuccessDataResult<int>(product.Id);
        }

        public IDataResult<List<ProductDetailDto>> GetLimitedProductDetailsByProduct(int limit)
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails().Take(limit).ToList());
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetailByBrandId(int brandId)
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails(i => i.BrandId == brandId));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetailByCategoryId(int categoryId)
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails(i => i.CategoryId == categoryId));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetailByProductId(int productId)
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails(i => i.Id == productId));
        }
        [CacheAspect]
        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetailsByMinPriceAndMaxPrice(decimal minPrice, decimal maxPrice)
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails(i => i.Price >= minPrice && i.Price <= maxPrice));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetailsFilterAsc()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails().OrderBy(i => i.Price).ToList());
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetailsFilterDesc()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails().OrderByDescending(i => i.Price).ToList());
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetailsMeasurement()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails()
                .OrderByDescending(i => i.Rating).ToList());
        }
        [LogAspect(typeof(DatabaseLogger))]
        [SecuredOperation("admin,user")]
        [CacheRemoveAspect("IProductService.Get")]
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Update(Product entity)
        {
            _productDal.Update(entity);
            return new SuccessResult(Messages.ProductUpdated);
        }
    }
}
