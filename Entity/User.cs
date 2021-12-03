using System;
using System.Collections.Generic;

#nullable disable

namespace Entity
{
    public partial class User
    {
        public User()
        {
            Brands = new HashSet<Brand>();
            Categories = new HashSet<Category>();
            Pictures = new HashSet<Picture>();
            ProductCreatedByNavigations = new HashSet<Product>();
            ProductModifiedByNavigations = new HashSet<Product>();
        }

        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }

        public virtual ICollection<Brand> Brands { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Picture> Pictures { get; set; }
        public virtual ICollection<Product> ProductCreatedByNavigations { get; set; }
        public virtual ICollection<Product> ProductModifiedByNavigations { get; set; }
    }
}
