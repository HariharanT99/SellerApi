using CustomModel;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepository
{
    public interface IProductRepository
    {
        Task<ResponseCustomModel<bool>> AddProduct(Product model);
        ResponseCustomModel<IEnumerable<Product>> GetProduct();
    }
}
