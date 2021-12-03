using System;
using System.Collections.Generic;

#nullable disable

namespace Entity
{
    public partial class UserLogin
    {
        public string LoginProvIder { get; set; }
        public string ProvIderKey { get; set; }
        public string ProvIderDisplayName { get; set; }
        public Guid UserId { get; set; }
    }
}
