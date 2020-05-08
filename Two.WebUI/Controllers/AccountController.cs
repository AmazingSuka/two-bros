using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Boxters.Application.Accounts.Commands.CreateAccount;
using Boxters.Application.Accounts.Commands.ChangeRole;
using Boxters.Application.Accounts.Queries.GetUsersList;
using Boxters.Application.Accounts.Queries.SignInAccount;
using Boxters.Application.Accounts.Queries.SignOutAccount;
using Boxters.Application.Exceptions;
using Boxters.WebUI.Infrastructure;
using Boxters.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Boxters.Application.Infrastructure;
using Two.Application.Exceptions;

namespace Boxters.WebUI.Controllers
{
    public class AccountController : BaseController
    {
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Users()
        {
            return View(await Mediator.Send(new GetUsersListCommand()));
        }

        [HttpPost]
        [Authorize(Roles = Roles.Administrator)]
        public async Task<IActionResult> ChangeRole(int id)
        {
            try
            {
                await Mediator.Send(new ChangeRoleCommand(id));
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel model)
        {
            try
            {
                await Mediator.Send(model.Command);
                HttpContext.Session.Set(SessionKeys.SignUpSuccess, Array.Empty<byte>());

                return RedirectToAction("SignIn", "Account");
            }
            catch (AccountAlreadyExistException)
            {
                HttpContext.Session.Set(SessionKeys.AccountAlreadyExistError, Array.Empty<byte>());
            }
            catch (PasswordsNotEqualException)
            {
                HttpContext.Session.Set(SessionKeys.PasswordsNotEqualError, Array.Empty<byte>());
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return RedirectToAction("SignUp");
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInViewModel model)
        {
            try
            {
                await Mediator.Send(new SignInAccountQuery { Login = model.Login, Password = model.Password, HttpContext = HttpContext });
                return RedirectToAction("Index", "Home");
            }
            catch (InvalidPasswordException)
            {
                HttpContext.Session.Set(SessionKeys.AuthError, Array.Empty<byte>());
                return RedirectToAction("SignIn");
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> SignOut()
        {
            await Mediator.Send(new SignOutAccountQuery { HttpContext = HttpContext });
            return RedirectToAction("Index", "Home");
        }
    }
}