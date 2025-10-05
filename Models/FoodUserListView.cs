using CalorieCalc.Models;
using CalorieCalc.ViewModels;
using System.Collections.Generic;

namespace CalorieCalc.Models
{
    public class FoodUserListView : MealTypeView
    {
        public List<FoodDto> Foods { get; set; }
        public List<User> users { get; set; }

        private List<Meal> _meals;
        public List<Meal> Meals
        {
            get => _meals;
            set
            {
                _meals = value;
                _meals.Insert(0, new Meal { MealId = 0, MealType = "All" });
            }
        }

        public string CheckActiveMealType(string d) =>
            d?.ToLower() == ActiveMealType?.ToLower() ? "active" : "";
    }

}
