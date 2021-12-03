using Identity.CustomModel;
using Identity.IAction;
using Identity.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SellerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserAction _userAction;
        private readonly IRoleAction _roleAction;
        private readonly IAccountAction _accountAction;
        private readonly SignInManager<User> _signInManager;

        public AccountController(IUserAction userAction, IRoleAction roleAction, IAccountAction accountAction, SignInManager<User> signInManager)
        {
            this._userAction = userAction;
            this._roleAction = roleAction;
            this._accountAction = accountAction;
            this._signInManager = signInManager;
        }

        //User

        [HttpPost("CreateUser")]
        public async Task<IdentityResult> CreateUser(UserCustomModel user)
        {
            try
            {
                var result = await _userAction.Create(user);

                return result;

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost("UpdateUser")]
        public async Task<IdentityResult> UpdateUser(UserCustomModel user)
        {
            try
            {
                var result = await _userAction.Update(user);

                return result;

            }
            catch (Exception)
            {

                throw;
            }
        }

        //Role

        [HttpPost("CreateRole")]
        public async Task<IdentityResult> CreateRole(RoleCustomModel role)
        {
            try
            {
                var result = await _roleAction.Create(role);

                return result;

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost("UpdateRole")]
        public async Task<IdentityResult> UpdateRole(RoleCustomModel role)
        {
            try
            {
                var result = await _roleAction.Update(role);

                return result;

            }
            catch (Exception)
            {

                throw;
            }
        }


        //Signin

        [HttpPost]
        public async Task<Microsoft.AspNetCore.Identity.SignInResult> Login(UserCustomModel user)
        {
            try
            {
                var result = await _accountAction.Login(user);

                return result;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
