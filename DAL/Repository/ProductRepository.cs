using CustomModel;
using DAL.Data;
using DAL.IRepository;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class ProductRepository: GenericRepository, IProductRepository
    {
        public ProductRepository(SellerAppContext db) : base(db) 
        {
        }

        public async Task<ResponseCustomModel<bool>> AddProduct(Product model, IFormFile file)
        {
            ResponseCustomModel<bool> result = new();

            try
            {
                var Ver = Path.Combine(model.Category.Name, model.Brand.Name, DateTime.Now.Ticks.ToString());

                var pic = new Picture { ProductId = model.Id, Name = file.FileName, Version = Ver, UploadedBy = model.CreatedBy };

                model.Pictures.Add(pic);

                await Db.Products.AddAsync(model);

                SaveFile(file, model.Category.Name, model.Brand.Name, Ver);

                await Db.SaveChangesAsync();

            }
            catch
            {
                result.Error.Succeeded = false;
                result.Error.ErrorMsg = "Something went wrong";
                result.Error.ErrorCode = 500;
            }

            return result;
        }

        //Save file
        private void SaveFile(IFormFile file, string category, string brand, string filePath)
        {
            try
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "ProductImage", category, brand);

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }


                //Path for save file

                //var fullPath = Path.Combine(path, fileName);

                var stream = new FileStream((filePath + ".png"), FileMode.Create);

                file.CopyTo(stream);

                stream.Close();

                //return fileName;
            }
            catch
            {
                throw new Exception("Something Went wrong");
            }
        }

        //Get product
        public ResponseCustomModel<IEnumerable<Product>> GetProduct()
        {
            ResponseCustomModel<IEnumerable<Product>> result = new();
            try
            {
                //var product = Db.Products.Join(Db.Pictures,
                //    p => p.Id,
                //    i => i.ProductId,
                //    (p, i) =>
                //    new
                //    {
                //        ProductId = p.Id,
                //        ProductName = p.Name,
                //        BrandId = p.BrandId,
                //        CategoryId = p.CategoryId,
                //        Stock = p.InStock,
                //        Description = p.Description,
                //        CreatedOn = p.CreatedOn,
                //        ExpiryOn = p.ExpiryOn,
                //        Price = p.Price,
                //        CreatedBy = p.CreatedBy,
                //        IsActive = p.IsActive,
                //        PictureId = i.Id,
                //        PictureName = i.Name,
                //        Version = i.Version
                //    })
                //    .Join(Db.Categories,
                //    p => p.CategoryId,
                //    c => c.Id,
                //    (p, c) =>
                //    new
                //    {
                //        ProductId = p.ProductId,
                //        ProductName = p.ProductName,
                //        Stock = p.Stock,
                //        Description = p.Description,
                //        CreatedOn = p.CreatedOn,
                //        ExpiryOn = p.ExpiryOn,
                //        Price = p.Price,
                //        CreatedBy = p.CreatedBy,
                //        IsActive = p.IsActive,
                //        PictureId = p.PictureId,
                //        PictureName = p.PictureName,
                //        Version = p.Version,
                //        BrandId = p.BrandId,
                //        CategoryId = c.Id,
                //        CategoryName = c.Name
                //    })
                //    .Join(Db.Brands,
                //    p => p.BrandId,
                //    b => b.Id,
                //    (p, b) =>
                //    new
                //    {
                //        ProductId = p.ProductId,
                //        ProductName = p.ProductName,
                //        Stock = p.Stock,
                //        Description = p.Description,
                //        CreatedOn = p.CreatedOn,
                //        ExpiryOn = p.ExpiryOn,
                //        Price = p.Price,
                //        CreatedBy = p.CreatedBy,
                //        IsActive = p.IsActive,
                //        PictureId = p.PictureId,
                //        PictureName = p.PictureName,
                //        Version = p.Version,
                //        CategoryId = p.CategoryId,
                //        CategoryName = p.CategoryName,
                //        BrandId = b.Id,
                //        BrandName = b.Name
                //    }).ToList();

                var products = Db.Products.Where(p=> p.InStock > 0 && p.ExpiryOn > DateTime.UtcNow).Include(p => p.Pictures).Include(p => p.Brand).Include(p => p.Category);

                result.Data = products;
            }
            catch
            {
                result.Error.Succeeded = false;
                result.Error.ErrorMsg = "Something went wrong";
                result.Error.ErrorCode = 500;
            }

            return result;
        }
    }
}
