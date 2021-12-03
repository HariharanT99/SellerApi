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
        protected IDbConnection Connection { get; private set; }

        public GenericRepository(IDbConnection connection)
        {
            this.Connection = connection;
        }
    }
}
