using BLL.ILogic;
using CustomModel;
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
        public async Task<ResponseCustomModel<bool>> AddProduct(ProductCustomModel model)
        {
            var result = await _service.ProductService.AddProduct(model);

            return result;
        
        }

        //Get product
        [HttpGet("GetProduct")]
        public ResponseCustomModel<IList<ProductCustomModel>> GetProduct()
        {
            var result = _service.ProductService.GetProduct();

            return result;
        }

        //Get Category
        [HttpGet("GetCategory")]
        public ResponseCustomModel<IList<CategoryCustomModel>> GetCategory()
        {
            var result = _service.ProductService.GetCategory();

            return result;
        }

        //Get brand
        [HttpGet("GetBrand")]
        public ResponseCustomModel<IList<BrandCustomModel>> GetBrand()
        {
            var result = _service.ProductService.GetBrand();

            return result;
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
