using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxters.Application.ShoppingCart.Queries.GetCount
{
    public class GetCountQuery : CartRequest, IRequest<int>
    {

    }
}
