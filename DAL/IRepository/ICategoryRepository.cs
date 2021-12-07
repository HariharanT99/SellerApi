using CustomModel;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepository
{
    public interface ICategoryRepository
    {
        ResponseCustomModel<IEnumerable<Category>> GetCategory();
        Task<ResponseCustomModel<bool>> Create(Category category);
        Category GetCategoryById(int id);

    }
}
