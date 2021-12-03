using System;
using System.Collections.Generic;

#nullable disable

namespace Entity
{
    public partial class Picture
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public int ProductId { get; set; }
        public Guid UploadedBy { get; set; }

        public virtual Product Product { get; set; }
        public virtual User UploadedByNavigation { get; set; }
    }
}
