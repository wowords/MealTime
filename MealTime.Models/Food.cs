using MealTime.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealTime.Models
{
    public class Food
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Recipe { get; set; }
        public string Name { get; set; }
        public double Rating { get; set; }
        public FoodCategory Category { get; set; }
        public string? Details { get; set; }
        public FoodType Type { get; set; }
        public bool IsHealthy { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<Meal> Meals { get; set; }

    }
}
