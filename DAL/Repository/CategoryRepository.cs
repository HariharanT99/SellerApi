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
        //private readonly SellerAppContext Db;

        public CategoryRepository(SellerAppContext db): base(db)
        {
            //this.Db = db;
        }

        //Get Category
        public ResponseCustomModel<IEnumerable<Category>> GetCategory()
        {
            ResponseCustomModel<IEnumerable<Category>> result = new();
            try
            {
                result.Data = Db.Categories;
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
        public Category GetCategoryById(int id)
        {
            var category = new Category();
            try
            {
                category = Db.Categories.Find(id);
            }
            catch
            {

                throw;
            }
            return category;
        }

        //Add category
        public async Task<ResponseCustomModel<bool>> Create(Category model)
        {
            ResponseCustomModel<bool> result = new();
            try
            {
                Db.Categories.Add(model);

                Db.SaveChanges();   
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
