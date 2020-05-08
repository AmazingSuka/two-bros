using Boxters.Application.Exceptions;
using Boxters.Application.Infrastructure;
using Boxters.Application.Interfaces;
using Boxters.Domain.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Boxters.Application.Accounts
{
    public class UserAccount
    {
        private readonly Account _account;

        public UserAccount(Account account)
        {
            _account = account;
        }

        public UserAccount()
        {

        }

        public async Task SignUpAsync(IBoxBoxContext context, CancellationToken cancellationToken)
        {
            PasswordHasher<Account> passwordHasher = new PasswordHasher<Account>();

            Account contextEntity = new Account
            {
                Login = _account.Login,
                Email = _account.Email,
                IsSuperUser = false,
                IsOwner = false,
                Created = DateTime.Now
            };

            if (context.Account.Count() == 0)
            {
                contextEntity.IsSuperUser = true;
                contextEntity.IsOwner = true;
            }

            contextEntity.Password = passwordHasher.HashPassword(contextEntity, _account.Password);

            await context.Account.AddAsync(contextEntity);
            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task SignInAsync(Account contextEntity, HttpContext httpContext)
        {
            if (!VerifyPassword(contextEntity))
            {
                throw new InvalidPasswordException("The password is wrong.");
            }

            IList<Claim> claims = new List<Claim> { new Claim(ClaimTypes.Name, _account.Login) };

            if (contextEntity.IsSuperUser)
            {
                claims.Add(new Claim(ClaimTypes.Role, Roles.Administrator));
            }

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            await httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);
        }

        public async Task SignOutAsync(HttpContext httpContext)
        {
            await httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        private bool VerifyPassword(Account contextEntity)
        {
            PasswordHasher<Account> hasher = new PasswordHasher<Account>();
            PasswordVerificationResult result = hasher.VerifyHashedPassword(contextEntity, contextEntity.Password, _account.Password);

            return result.Equals(PasswordVerificationResult.Success);
        }
    }
}
