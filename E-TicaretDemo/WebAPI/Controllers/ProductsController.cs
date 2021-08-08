﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getproductdetails")]
        public IActionResult GetProductDetails()
        {
            var result = _productService.GetProductDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getproductdetailsbyminpriceandmaxprice")]
        public IActionResult GetProductDetailsByMinPriceAndMaxPrice(decimal minPrice, decimal maxPrice)
        {
            var result = _productService.GetProductDetailsByMinPriceAndMaxPrice(minPrice, maxPrice);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getproductdetailsdesc")]
        public IActionResult GetProductDetailsDesc()
        {
            var result = _productService.GetProductDetailsFilterDesc();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getproductdetailsmeasurement")]
        public IActionResult GetProductDetailsMeasurement()
        {
            var result = _productService.GetProductDetailsMeasurement();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getproductdetailsasc")]
        public IActionResult GetProductDetailsAsc()
        {
            var result = _productService.GetProductDetailsFilterAsc();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getproductdetailsbypage")]
        public IActionResult GetProductDetailsByPage(int page, int pageSize)
        {
            var result = _productService.GetAllProductDetailsByProductWithPage(page, pageSize);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getproductdetailslimit")]
        public IActionResult GetProductDetailsLimit(int limit)
        {
            var result = _productService.GetLimitedProductDetailsByProduct(limit);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getproductdetailbyproductid")]
        public IActionResult GetProductDetailByProductId(int productId)
        {
            var result = _productService.GetProductDetailByProductId(productId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getproductdetailbybrandid")]
        public IActionResult GetProductDetailByBrandId(int brandId)
        {
            var result = _productService.GetProductDetailByBrandId(brandId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getproductdetailbycategoryid")]
        public IActionResult GetProductDetailByCategoryId(int categoryId)
        {
            var result = _productService.GetProductDetailByCategoryId(categoryId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbycategory")]
        public IActionResult GetByCategory(int categoryId)
        {
            var result = _productService.GetAllByCategory(categoryId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("getidadd")]
        public IActionResult GetIdAdd(Product product)
        {
            var result = _productService.GetByIdAdd(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(Product product)
        {
            var result = _productService.Delete(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(Product product)
        {
            var result = _productService.Update(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
