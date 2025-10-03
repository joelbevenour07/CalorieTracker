using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CalorieCalc.Models
{
    public class Meal
    {
        [Required]
        public int MealId { get; set; }

        [Required]
        public string MealType { get; set; }

        public List<Food> Foods { get; set; }



    }
}
