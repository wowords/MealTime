using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealTime.Models
{
    public class Meal
    {
        public int Id { get; set; }
        public List<Food> Foods { get; set; }
        public double Rating { get; set; }
        public DateTime LastOnMenu { get; set; }
    }
}
