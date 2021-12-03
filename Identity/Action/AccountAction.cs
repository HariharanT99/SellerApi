using Identity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Identity.CustomModel;
using Identity.IAction;
using Microsoft.AspNetCore.Identity;

namespace Identity.Action
{
    public class AccountAction : IAccountAction
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public AccountAction(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            this._signInManager = signInManager;
            this._userManager = userManager;
        }

        public async Task<SignInResult> Login(UserCustomModel user)
        {
            try
            {
                var appUser = await _userManager.FindByNameAsync(user.Email);
                if (appUser != null)
                { 
                    var result = await _signInManager.PasswordSignInAsync(appUser.Email, user.Password, false, false);

                    return result;
                }

                var res = SignInResult.Failed;
                return res;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
