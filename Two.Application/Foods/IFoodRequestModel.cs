
using Microsoft.AspNetCore.Http;

namespace Boxters.Application.Foods
{
    public interface IFoodRequestModel : IFoodRequest
    {
        string Name { get; set; }
        double Price { get; set; }
        string Description { get; set; }
        double Weight { get; set; }
        short Size { get; set; }
        short Protein { get; set; }
        short Fats { get; set; }
        short Carbohydrates { get; set; }
        short Calories { get; set; }
        int TypeId { get; set; }
    }
}
