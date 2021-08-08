using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Http;
using Business.Abstract;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using Core.Utilities.Business;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using DataAccess.Abstract;
using Entities.Concrete;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Business.BaseOperations;

namespace Business.Concerete
{
    public class ProductImagesManager : IProductImagesService
    {
        private IProductImageDal _productImageDal;

        public ProductImagesManager(IProductImageDal productImageDal)
        {
            _productImageDal = productImageDal;
        }
        [ValidationAspect(typeof(ProductImagesValidator))]
        [SecuredOperation("admin")]
        public IResult Add(IFormFile file, ProductsImage productsImage)
        {
            IResult result = BusinessRules.Run(CheckIfImageLimitExpired(productsImage.ProductId), CheckIfImageExtensionValid(file));
            if (result != null) { return result;}
            productsImage.ImagePath = FileHelper.Add(file);
            productsImage.Date = DateTime.Now;
            _productImageDal.Add(productsImage);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        public IResult Delete(ProductsImage productsImage)
        {
            string path = GetById(productsImage.Id).Data.ImagePath;
            FileHelper.Delete(path);
            _productImageDal.Delete(productsImage);
            return new SuccessResult();
        }

        public IResult DeleteById(int id)
        {
            var result = _productImageDal.GetAll(i => i.ProductId == id);
            if (result.Any())
            {
                foreach (var productImage in result)
                {
                    Delete(productImage);
                }
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        public IDataResult<List<ProductsImage>> GetAll(Expression<Func<ProductsImage, bool>> filter = null)
        {
            return new SuccessDataResult<List<ProductsImage>>(_productImageDal.GetAll());
        }

        public IDataResult<List<ProductsImage>> GetAllByProductId(int id)
        {
            return new SuccessDataResult<List<ProductsImage>>(CheckIfProductHaveNoImage(id));
        }

        public IDataResult<ProductsImage> GetById(int id)
        {
            return new SuccessDataResult<ProductsImage>(_productImageDal.Get(i => i.ProductId == id));
        }
        [SecuredOperation("admin")]
        public IResult Update(IFormFile file, ProductsImage productsImage)
        {
            IResult result = BusinessRules.Run(CheckIfImageLimitExpired(productsImage.ProductId), CheckIfImageExtensionValid(file));
            if(result != null) { return result; }
            ProductsImage oldProductImage = GetById(productsImage.Id).Data;
            productsImage.ImagePath = FileHelper.Update(file, oldProductImage.ImagePath);
            productsImage.Date = DateTime.Now;
            productsImage.ProductId = oldProductImage.ProductId;
            _productImageDal.Update(productsImage);
            return new SuccessResult();
        }

        private IResult CheckIfImageLimitExpired(int productid)
        {
            int result = _productImageDal.GetAll(i => i.ProductId == productid).Count;
            if (result >= 5)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        private IResult CheckIfImageExtensionValid(IFormFile file)
        {
            bool isValidFileExtension = Messages.ValidImageFileTypes.Any(i => i == Path.GetExtension(file.FileName).ToUpper());
            if (!isValidFileExtension)
            {
                return new ErrorResult(Messages.InvalidImageExtension);
            }
            return new SuccessResult();
        }

        private List<ProductsImage> CheckIfProductHaveNoImage(int productid)
        {
            string path = @"\Images\default.png";
            var result = _productImageDal.GetAll(i => i.ProductId == productid);
            if (!result.Any())
            {
                return new List<ProductsImage> { new ProductsImage { ProductId = productid, ImagePath = path } };
            }
            return result;
        }
    }
}