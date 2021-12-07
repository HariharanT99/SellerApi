using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomModel
{
    public class GetProductCustomModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int BrandId { get; set; }

        public int CategoryId { get; set; }
        public int InStock { get; set; }

        public string Description { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime ExpiryOn { get; set; }

        public decimal Price { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid? ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }
        public bool IsActive { get; set; }

        public DateTime? DeletedOn { get; set; }

        public IList<PictureCustomModel> Pictures { get; set; }
        public CategoryCustomModel Category { get; set; }
        public BrandCustomModel Brand { get; set; }

    }
}
