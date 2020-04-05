using MediatR;

namespace Boxters.Application.Foods.Generic
{
    public interface IFoodRequest<out TResponse> : IRequest<TResponse>
    {
        int Id { get; set; }
    }
}
