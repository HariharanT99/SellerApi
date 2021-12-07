using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.IConfiguration;
using DAL.IRepository;
using DAL.Repository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
    public class UnitOfWork: IUnitOfWork
    {
        //private readonly IDbConnection _connection;
        //private readonly SellerAppContext _db;

        public IProductRepository ProductRepository { get; private set; }

        public ICategoryRepository CategoryRepository { get; private set; }
        public IBrandRepository BrandRepository { get; private set; }
        public UnitOfWork(SellerAppContext db)
        {
            //_connection = new SqlConnection(connectionString);

            //_db = db;

            this.ProductRepository = new ProductRepository(db);

            this.CategoryRepository = new CategoryRepository(db);
            this.BrandRepository = new BrandRepository(db);
            
        }


    }
}
