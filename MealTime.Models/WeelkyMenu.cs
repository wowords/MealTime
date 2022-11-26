using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealTime.Models
{
    public class WeeklyMenu
    {
        public int Id { get; set; }
        public List<Meal> Meals { get; set; }
        public DateTime CurrentWeek { get; set; }
    }
}
