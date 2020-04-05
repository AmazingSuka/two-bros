using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxters.Application.Foods.Queries.GetFoodDetail
{
    public class GetFoodDetailQueryValidator : AbstractValidator<GetFoodDetailQuery>
    {
        public GetFoodDetailQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
