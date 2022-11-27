using MealTime.Models.Enums;

namespace MealTime.API.Infrastructure.DataObjects
{
    public class FoodDto
    {
        public int Id { get; set; }
        public string Recipe { get; set; }
        public string Name { get; set; }
        public double Rating { get; set; }
        public FoodCategory Category { get; set; }
        public string? Details { get; set; }
        public FoodType Type { get; set; }
        public bool IsHealthy { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<MealDto> Meals { get; set; }
    }
}
