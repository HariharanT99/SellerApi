using System;
using System.Collections.Generic;

#nullable disable

namespace Entity
{
    public partial class UserToken
    {
        public Guid UserId { get; set; }
        public string LoginProvIder { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
