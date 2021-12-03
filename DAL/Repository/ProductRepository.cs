using CustomModel;
using DAL.Data;
using DAL.IRepository;
using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class ProductRepository: GenericRepository, IProductRepository
    {
        private readonly SellerAppContext _db;
        public ProductRepository(IDbConnection connection, SellerAppContext db) : base(connection) 
        {
            this._db = db;    
        }

        public async Task<ResponseCustomModel<bool>> AddProduct(Product model)
        {
            ResponseCustomModel<bool> result = new();

            try
            {

                await _db.Products.AddAsync(model);

                _db.SaveChanges();

            }
            catch (Exception)
            {
                result.Error.Succeeded = false;
                result.Error.ErrorMsg = "Something went wrong";
                result.Error.ErrorCode = 500;
            }

            return result;
        }

        //Get product
        public ResponseCustomModel<IEnumerable<Product>> GetProduct()
        {
            ResponseCustomModel<IEnumerable<Product>> result = new();
            try
            {
                var product = _db.Products;

                result.Data = product;
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
