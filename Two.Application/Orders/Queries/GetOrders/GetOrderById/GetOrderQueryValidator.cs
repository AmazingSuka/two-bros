using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxters.Application.Orders.Queries.GetOrders.GetOrderById
{
    public class GetOrderQueryValidator : AbstractValidator<GetOrderQuery>
    {
        public GetOrderQueryValidator()
        {
            RuleFor(x => x.OrderId).NotNull();
        }
    }
}
