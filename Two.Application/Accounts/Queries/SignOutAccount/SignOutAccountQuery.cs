using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxters.Application.Accounts.Queries.SignOutAccount
{
    public class SignOutAccountQuery : IRequest
    {
        public HttpContext HttpContext { get; set; }
    }
}
