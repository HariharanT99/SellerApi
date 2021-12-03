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
    public class CategoryRepository : GenericRepository, ICategoryRepository
    {
        private readonly SellerAppContext _db;

        public CategoryRepository(IDbConnection connection, SellerAppContext db): base(connection)
        {
            this._db = db;
        }

        //Get Category
        public ResponseCustomModel<IEnumerable<Category>> Get()
        {
            ResponseCustomModel<IEnumerable<Category>> result = new();
            try
            {
                result.Data = _db.Categories;
            }
            catch (Exception)
            {
                result.Error.Succeeded = false;
                result.Error.ErrorMsg = "Something went wrong";
                result.Error.ErrorCode = 500;
            }

            return result;
        }

        //Add category
        public async Task<ResponseCustomModel<bool>> Create(Category model)
        {
            ResponseCustomModel<bool> result = new();
            try
            {
                _db.Categories.Add(model);

                _db.SaveChanges();   
            }
            catch (Exception ex)
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
