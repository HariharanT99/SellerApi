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
    public class BrandRepository: GenericRepository, IBrandRepository
    {
        private readonly SellerAppContext _db;

        public BrandRepository(IDbConnection connection, SellerAppContext db): base(connection)
        {
            this._db = db;
        }

        //Get brands

        public ResponseCustomModel<IEnumerable<Brand>> GetBrand()
        {
            ResponseCustomModel<IEnumerable<Brand>> result = new();
            try
            {
                result.Data = _db.Brands;
            }
            catch (Exception)
            {
                result.Error.Succeeded = false;
                result.Error.ErrorMsg = "Something went wrong";
                result.Error.ErrorCode = 500;
            }

            return result;
        }

        public async Task<ResponseCustomModel<bool>> CreateBrand(Brand model)
        {
            ResponseCustomModel<bool> result = new();
            try
            {
                await _db.Brands.AddAsync(model);

                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                result.Error.Succeeded = false;
                result.Error.ErrorMsg = "Something went wrong";
                result.Error.ErrorCode = 500;
            }

            return result;
        }

    }
}
