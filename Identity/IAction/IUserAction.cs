using Identity.CustomModel;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.IAction
{
    public interface IUserAction
    {
        Task<IdentityResult> Create(UserCustomModel user);
        Task<IdentityResult> Update(UserCustomModel user);

    }
}
