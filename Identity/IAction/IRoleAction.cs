using Identity.CustomModel;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.IAction
{
    public interface IRoleAction
    {
        Task<IdentityResult> Create(RoleCustomModel role);
        Task<IdentityResult> Update(RoleCustomModel role);
    }
}
