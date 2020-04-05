
namespace Boxters.Application.Foods.Generic
{
    public abstract class FoodRequest<TResponse> : IFoodRequest<TResponse>
    {
        public int Id { get; set; }
    }
}
