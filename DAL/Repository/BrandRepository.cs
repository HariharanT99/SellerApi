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
        //private readonly SellerAppContext Db;

        public BrandRepository(SellerAppContext db): base(db)
        {
            //this.Db = db;
        }

        //Get brands

        public ResponseCustomModel<IEnumerable<Brand>> GetBrand()
        {
            ResponseCustomModel<IEnumerable<Brand>> result = new();
            try
            {
                result.Data = Db.Brands;
            }
            catch (Exception)
            {
                result.Error.Succeeded = false;
                result.Error.ErrorMsg = "Something went wrong";
                result.Error.ErrorCode = 500;
            }

            return result;
        }

        //Get brand by Id
        public Brand GetBrandById(int id)
        {
            var brand = new Brand();
            try
            {
                brand = Db.Brands.Find(id);
            }
            catch
            {
                throw new Exception("Something went wrong");
            }
            return brand;
        }


        public async Task<ResponseCustomModel<bool>> CreateBrand(Brand model)
        {
            ResponseCustomModel<bool> result = new();
            try
            {
                await Db.Brands.AddAsync(model);

                Db.SaveChanges();
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
