﻿using BLL.ILogic;
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
    public class CategoryService: GenericService, ICategoryService
    {
        public CategoryService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        //Add category
        public async Task<ResponseCustomModel<bool>> Create(CategoryCustomModel model)
        {
            ResponseCustomModel<bool> result = new();
                var cat = new Category()
                {
                    Name = model.Name,
                    CreatedBy = new Guid("9C25E902-48F2-4D24-3490-08D9B63E75B3"),
                    CreatedOn = DateTime.UtcNow,
                    IsActive = true,
                };

                await UnitOfWork.CategoryRepository.Create(cat);

            return result;
        }

        //Get category
        public ResponseCustomModel<IList<CategoryCustomModel>> GetCategory()
        {
            ResponseCustomModel<IList<CategoryCustomModel>> result = new();
            List<CategoryCustomModel> categories = new();

            var category = UnitOfWork.CategoryRepository.GetCategory();

            foreach (var item in category.Data)
            {
                CategoryCustomModel cat = new();

                cat.Id = item.Id;
                cat.Name = item.Name;


                categories.Add(cat);
            }

            result.Data = categories;

            return result;
        }
    }
}
