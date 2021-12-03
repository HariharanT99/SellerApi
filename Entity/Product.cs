using System;
using System.Collections.Generic;

#nullable disable

namespace Entity
{
    public partial class Product
    {
        public Product()
        {
            Pictures = new HashSet<Picture>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public int InStock { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ExpiryOn { get; set; }
        public decimal Price { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsActive { get; set; }
        public DateTime? DeletedOn { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
        public virtual User CreatedByNavigation { get; set; }
        public virtual User ModifiedByNavigation { get; set; }
        public virtual ICollection<Picture> Pictures { get; set; }
    }
}
