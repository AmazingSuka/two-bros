using MediatR;

namespace Boxters.Application.Foods
{
    public interface IFoodRequest : IRequest
    {
        int Id { get; set; }
    }
}