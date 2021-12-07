using CustomModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ILogic
{
    public interface IBrandService
    {
        Task<ResponseCustomModel<bool>> Create(BrandCustomModel model);
        ResponseCustomModel<IList<BrandCustomModel>> GetBrand();
    }
}
