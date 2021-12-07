using BLL.ILogic;
using CustomModel;
using DAL.IConfiguration;
using Entity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapster;

namespace BLL.Logic
{
    public class ProductService: GenericService, IProductService
    {
        public ProductService(IUnitOfWork unitOfWork): base(unitOfWork)
        {

        }

        //Add Product
        public async Task<ResponseCustomModel<bool>> AddProduct(ProductCustomModel model)
        {
            ResponseCustomModel<bool> result = new();

            if (model.Name == null || model.Description == null || model.ExpiryOn <= DateTime.UtcNow || model.File == null)
            {
                result.Error.Succeeded = false;
                result.Error.ErrorMsg = "Invalid data";
                result.Error.ErrorCode = 422;
                return result;
            }

            var category = UnitOfWork.CategoryRepository.GetCategoryById(model.CategoryId);

            var brand = UnitOfWork.BrandRepository.GetBrandById(model.BrandId);


            var product = new Product
            {
                Name = model.Name,
                CategoryId = model.CategoryId,
                Category = category,
                BrandId = model.BrandId,
                Brand = brand,
                Price = model.Price,
                CreatedBy = new Guid("9C25E902-48F2-4D24-3490-08D9B63E75B3"),
                InStock = model.InStock,
                ExpiryOn = model.ExpiryOn,
                Description = model.Description,
                CreatedOn = DateTime.UtcNow,
                IsActive = true
            };

            result = await UnitOfWork.ProductRepository.AddProduct(product, model.File);


            return result;
        }



        //Get product
        public ResponseCustomModel<IList<GetProductCustomModel>> GetProduct()
        {
            ResponseCustomModel<IList<GetProductCustomModel>> result = new();
            List<GetProductCustomModel> products = new();


            List<PictureCustomModel> pic = new();

            var product = UnitOfWork.ProductRepository.GetProduct();

            foreach (var item in product.Data)
            {
                GetProductCustomModel prod = new();
                BrandCustomModel brand = new();
                CategoryCustomModel cat = new();

                if (item.ExpiryOn <= DateTime.UtcNow && item.InStock <= 0)
                {
                    continue;
                }
                prod.Id = item.Id;
                prod.Name = item.Name;
                prod.CategoryId = item.CategoryId;
                prod.BrandId = item.BrandId;
                prod.Price = item.Price;
                prod.Description = item.Description;
                prod.ExpiryOn = item.ExpiryOn;
                prod.InStock = item.InStock;

                brand.Id = item.Brand.Id;
                brand.Name = item.Brand.Name;

                prod.Brand = brand;

                cat.Id = item.Category.Id;
                cat.Name = item.Category.Name;

                products.Add(prod);
            };

            result.Data = products;

            return result;
        }


     
    }
}
