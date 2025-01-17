﻿using DAL.Data;
using DAL.IConfiguration;
using BLL.ILogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Logic
{
    public class Service : IService
    {
        private readonly IUnitOfWork _unitOfWork;
        public IProductService ProductService { get; set; }
        public ICategoryService CategoryService { get; set; }
        public IBrandService BrandService { get; set; }
        public Service(SellerAppContext db)
        {
            _unitOfWork = new UnitOfWork(db);


            ProductService = new ProductService(_unitOfWork);

            CategoryService = new CategoryService(_unitOfWork);

            BrandService = new BrandService(_unitOfWork);
        }

        //public Service(SellerAppContext db)
        //{
        //    _unitOfWork = new UnitOfWork(_connectionString, db);

        //}
    }
}
