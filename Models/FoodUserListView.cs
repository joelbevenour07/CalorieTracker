using CalorieCalc.Models;
using System.Collections.Generic;

namespace CalorieCalc.Models
{
    public class FoodUserListView : MealTypeView
    {
        public List<Food> foods { get; set; }

        public List<User> users { get; set; }

        public List<Meal> meals
        {
            get => meals;
            set
            {
                meals = value;
                meals.Insert(0,
                    new Meal { MealId = 5, MealType = "All" });
            }
        }

        public string CheckActiveMealType(string d) =>
            d.ToLower() == ActiveMealType.ToLower() ? "active" : "";
    }
}
