using MealTime.Models;

namespace MealTime.API.Infrastructure.DataObjects
{
    public class MealDto
    {
        public int Id { get; set; }
        public ICollection<int>? FoodIds { get; set; }
        public double? Rating { get; set; }
        public DateTime? LastOnMenu { get; set; }
        public bool HasHealthyFood { get; set; }
    }
}
