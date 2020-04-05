using Boxters.Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxters.Application.Accounts.Queries.SignInAccount
{
    public class SignInAccountQuery : IRequest
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public HttpContext HttpContext { get; set; }
    }
}
