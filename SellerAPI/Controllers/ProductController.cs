using BLL.ILogic;
using CustomModel;
using DAL.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SellerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IService _service;

        public ProductController(IService service)
        {
            this._service = service;
        }

        //Add product
        [HttpPost("PostProduct")]
        public async Task<ResponseCustomModel<bool>> AddProduct([FromForm] ProductCustomModel model)
        {
            var result = await _service.ProductService.AddProduct(model);

            return result;
        
        }

        //Get product
        [HttpGet("GetProduct")]
        public IActionResult GetProduct()
        {
            var response = _service.ProductService.GetProduct();

            if (response.Error.Succeeded)
            {
                return Ok(response.Data);
            }

            return BadRequest(response.Error);
        }

        //Get Category
        [HttpGet("GetCategory")]
        public IActionResult GetCategory()
        {
            var response = _service.CategoryService.GetCategory();

            if (response.Error.Succeeded)
            {
                return Ok(response.Data);
            }

            return BadRequest(response.Error);
        }

        //Get brand
        [HttpGet("GetBrand")]
        public IActionResult GetBrand()
        {
            var response = _service.BrandService.GetBrand();
            if (response.Error.Succeeded)
            {
                return Ok(response.Data);
            }

            return BadRequest(response.Error);
        }

        //Create brand
        [HttpPost("PostBrand")]
        public async Task<ResponseCustomModel<bool>> AddBrand(BrandCustomModel model)
        {
            var result = await _service.BrandService.Create(model);

            return result;
        }

        //Create Category
        [HttpPost("PosCategory")]
        public async Task<ResponseCustomModel<bool>> AddCategory(CategoryCustomModel model)
        {
            var result = await _service.CategoryService.Create(model);

            return result;
        }
    }
}
