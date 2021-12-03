using System;
using System.Collections.Generic;

#nullable disable

namespace Entity
{
    public partial class Brand
    {
        public Brand()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsActive { get; set; }
        public DateTime? DeletedOn { get; set; }

        public virtual User CreatedByNavigation { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
