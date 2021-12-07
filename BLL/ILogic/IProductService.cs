using CustomModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ILogic
{
    public interface IProductService
    {
        Task<ResponseCustomModel<bool>> AddProduct(ProductCustomModel model);

        ResponseCustomModel<IList<GetProductCustomModel>> GetProduct();

    }
}
