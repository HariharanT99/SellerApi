﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Entity
{
    public partial class UserRole
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }

        public virtual Role Role { get; set; }
    }
}
