using Identity.CustomModel;
using Identity.IAction;
using Identity.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Action
{
    public class RoleAction : IRoleAction
    {
        private readonly RoleManager<Role> _roleManager;

        public RoleAction(RoleManager<Role> roleManager)
        {
            this._roleManager = roleManager;
        }

        public async Task<IdentityResult> Create(RoleCustomModel role)
        {
            try
            {
                var userRole = new Role()
                {
                    Name = role.Name
                };

                var result = await _roleManager.CreateAsync(userRole);

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IdentityResult> Update(RoleCustomModel role)
        {
            try
            {
                var userRole = await _roleManager.FindByIdAsync(role.Id);

                userRole.Name = role.Name;

                var result = await _roleManager.CreateAsync(userRole);

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
