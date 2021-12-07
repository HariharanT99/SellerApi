using CustomModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ILogic
{
    public interface ICategoryService
    {
        Task<ResponseCustomModel<bool>> Create(CategoryCustomModel model);
        ResponseCustomModel<IList<CategoryCustomModel>> GetCategory();

    }
}
