using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ILogic
{
    public interface IService
    {
        public IProductService ProductService { get; set; }
        public ICategoryService CategoryService { get; set; }
        public IBrandService BrandService { get; set; }
    }
}
