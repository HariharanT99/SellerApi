using BLL.ILogic;
using CustomModel;
using DAL.IConfiguration;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Logic
{
    public class BrandService: GenericService, IBrandService
    {
        public BrandService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        //Create brand
        public async Task<ResponseCustomModel<bool>> Create(BrandCustomModel model)
        {
            ResponseCustomModel<bool> result = new();

                var brand = new Brand()
                {
                    Name = model.Name,
                    CreatedBy = new Guid("9C25E902-48F2-4D24-3490-08D9B63E75B3"),
                    CreatedOn = DateTime.UtcNow,
                    IsActive = true
                };

                await UnitOfWork.BrandRepository.CreateBrand(brand);

            return result;
        }
    }
}
