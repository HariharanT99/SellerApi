﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Entity
{
    public partial class UserClaim
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
    }
}
