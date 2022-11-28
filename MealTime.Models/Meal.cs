using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealTime.Models
{
    public class Meal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public ICollection<Food>? Foods { get; set; }
        public double Rating { get; set; }
        public DateTime LastOnMenu { get; set; }
        public bool HasHealthyFood { get; set; }
    }
}
