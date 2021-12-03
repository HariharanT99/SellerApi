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
    public class UserAction : IUserAction
    {
        private readonly UserManager<User> _userManager;

        public UserAction(UserManager<User> userManager)
        {
            this._userManager = userManager;
        }

        public async Task<IdentityResult> Create(UserCustomModel user)
        {
            try
            {
                var appUser = new User()
                {
                    UserName = user.UserName,
                    Email = user.Email,
                };

                var result = await _userManager.CreateAsync(appUser, user.Password);

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IdentityResult> Update(UserCustomModel user)
        {
            try
            {
                var appUser = await _userManager.FindByIdAsync(user.Id);

                appUser.UserName = user.UserName;
                appUser.Email = user.Email;

                var result = await _userManager.UpdateAsync(appUser);

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
