using DAL.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class GenericRepository
    {
        protected SellerAppContext Db { get; private set; }

        public GenericRepository(SellerAppContext db)
        {
            this.Db = db;
        }
    }
}
