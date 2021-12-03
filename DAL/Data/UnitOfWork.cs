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
        private readonly IDbConnection _connection;
        private readonly SellerAppContext _db;

        public IProductRepository ProductRepository { get; private set; }

        public ICategoryRepository CategoryRepository { get; private set; }
        public IBrandRepository BrandRepository { get; private set; }
        public UnitOfWork(string connectionString)
        {
            _connection = new SqlConnection(connectionString);

            _db = new SellerAppContext();

            this.ProductRepository = new ProductRepository(_connection, _db);

            this.CategoryRepository = new CategoryRepository(_connection, _db);
            this.BrandRepository = new BrandRepository(_connection, _db);
            
        }


    }
}
