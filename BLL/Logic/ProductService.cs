using BLL.ILogic;
using CustomModel;
using DAL.IConfiguration;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

                var product = new Product
                {
                    Name = model.Name,
                    CategoryId = model.CategoryId,
                    BrandId = model.BrandId,
                    Price = model.Price,
                    CreatedBy = new Guid("9C25E902-48F2-4D24-3490-08D9B63E75B3"),
                    InStock = model.InStock,
                    ExpiryOn = model.ExpiryOn,
                    Description = model.Description,
                    CreatedOn = DateTime.UtcNow,
                    IsActive = true
                };

                result = await UnitOfWork.ProductRepository.AddProduct(product);

            return result;
        }

        //Get product
        public ResponseCustomModel<IList<ProductCustomModel>> GetProduct()
        {
            ResponseCustomModel<IList<ProductCustomModel>> result = new();
            ProductCustomModel prod = new();
            try
            {
                var product = UnitOfWork.ProductRepository.GetProduct();

                foreach (var item in product.Data)
                {
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

                    result.Data.Add(prod);
                }
            }
            catch (Exception)
            {
                result.Error.Succeeded = false;
                result.Error.ErrorMsg = "Something went wrong";
                result.Error.ErrorCode = 500;
                throw;
            }

            return result;
        }

        //Get category
        public ResponseCustomModel<IList<CategoryCustomModel>> GetCategory()
        {
            ResponseCustomModel<IList<CategoryCustomModel>> result = new();
            CategoryCustomModel cat = new();
            try
            {
                var category = UnitOfWork.ProductRepository.GetProduct();

                foreach (var item in category.Data)
                {
                    cat.Id = item.Id;
                    cat.Name = item.Name;


                    result.Data.Add(cat);
                }
            }
            catch (Exception)
            {
                result.Error.Succeeded = false;
                result.Error.ErrorMsg = "Something went wrong";
                result.Error.ErrorCode = 500;
                throw;
            }

            return result;
        }

        //Get brand
        public ResponseCustomModel<IList<BrandCustomModel>> GetBrand()
        {
            ResponseCustomModel<IList<BrandCustomModel>> result = new();
            BrandCustomModel prodBrand = new();
            try
            {
                var brand = UnitOfWork.ProductRepository.GetProduct();

                foreach (var item in brand.Data)
                {
                    prodBrand.Id = item.Id;
                    prodBrand.Name = item.Name;

                    result.Data.Add(prodBrand);
                }
            }
            catch (Exception)
            {
                result.Error.Succeeded = false;
                result.Error.ErrorMsg = "Something went wrong";
                result.Error.ErrorCode = 500;
                throw;
            }

            return result;
        }
    }
}
