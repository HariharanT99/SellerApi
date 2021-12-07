using DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IValueService
    {

    }

    public class ValueService : IValueService
    {
        private readonly SellerAppContext sellerAppContext;

        public ValueService(SellerAppContext sellerAppContext)
        {
            this.sellerAppContext = sellerAppContext;
        }
    }
}
