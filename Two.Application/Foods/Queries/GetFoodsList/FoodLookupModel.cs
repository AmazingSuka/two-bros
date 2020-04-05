namespace Boxters.Application.Foods.Queries.GetFoodsList
{
    public class FoodLookupModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public double Weight { get; set; }
        public short Size { get; set; }
        public string Category { get; set; }
        public string ImagePath { get; set; }
    }
}
