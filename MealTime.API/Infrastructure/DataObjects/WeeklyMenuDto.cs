namespace MealTime.API.Infrastructure.DataObjects
{
    public class WeeklyMenuDto
    {
        public int Id { get; set; }
        public ICollection<MealDto>? Meals { get; set; }
        public DateTime CurrentWeek { get; set; }
    }
}
