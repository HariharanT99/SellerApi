using CustomModel;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepository
{
    public interface IBrandRepository
    {
        Task<ResponseCustomModel<bool>> CreateBrand(Brand model);
        ResponseCustomModel<IEnumerable<Brand>> GetBrand();

        Brand GetBrandById(int id);
    }
}
