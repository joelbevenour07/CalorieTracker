using CalorieCalc.Models;
using CalorieCalc.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System;

namespace CalorieCalc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FoodListController : Controller
    {
        
        private FoodContext context { get; set; }


        public FoodListController(FoodContext ctx)
        {
            context = ctx;

        }

        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        
        public IActionResult List(string activeMealType = "all")
            {
                // get all meals
                var mealList = context.Meals.ToList();

                // base query
                IQueryable<Food> query = context.Foods;

                if (!string.Equals(activeMealType, "all", StringComparison.OrdinalIgnoreCase))
                {
                    query = query.Where(f => f.Meal.MealType.ToLower() == activeMealType.ToLower());
                }

                // project to DTOs
                var foodDtos = query.Select(f => new FoodDto
                {
                    FoodId = f.FoodId,
                    Name = f.Name,
                    Calories = f.Calories,
                    Carbs = f.Carbs,
                    Fats = f.Fats,
                    Cholesterol = f.Cholesterol,
                    Protein = f.Protein,
                    Sodium = f.Sodium,
                    FoodServing = f.FoodServing,
                    MealId = f.MealId,
                    MealType = f.Meal.MealType
                }).ToList();

                var vm = new FoodUserListView
                {
                    ActiveMealType = activeMealType,
                    Meals = mealList,
                    Foods = foodDtos
                    // Users = … set if needed
                };

                return View(vm);
            }

        [HttpGet]

        // public IActionResult FoodFilter(string activeMealType = "all")
        //     {
        //         var mealList = context.Meals.ToList();

        //         IQueryable<Food> query = context.Foods;

        //         if (!string.Equals(activeMealType, "all", StringComparison.OrdinalIgnoreCase))
        //         {
        //             query = query.Where(f => f.Meal.MealType.ToLower() == activeMealType.ToLower());
        //         }

        //         var foodList = query
        //             .Select(f => new FoodDto
        //             {
        //                 FoodId = f.FoodId,
        //                 Name = f.Name,
        //                 Calories = f.Calories,
        //                 Carbs = f.Carbs,
        //                 Fats = f.Fats,
        //                 Cholesterol = f.Cholesterol,
        //                 Protein = f.Protein,
        //                 Sodium = f.Sodium,
        //                 FoodServing = f.FoodServing,
        //                 MealId = f.MealId,
        //                 MealType = f.Meal.MealType
        //             })
        //             .ToList();

        //         var data = new FoodUserListView
        //         {
        //             ActiveMealType = activeMealType,
        //             Meals = mealList,
        //             Foods = foodList,
        //             users = null
        //         };

        //         return View(data);
        //     }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Foods
            = context.Foods.OrderBy(g => g.Name).ToList();
            return View("AddUpdate", new Food());
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            ViewBag.Action = "Update";
            ViewBag.Foods
            = context.Foods.OrderBy(g => g.Name).ToList();
            var food = context.Foods.Find(id);
            return View("AddUpdate", food);

        }

        [HttpPost]
        public IActionResult Update(Food food)
        {
            if (ModelState.IsValid)
            {
                if (food.FoodId == 0)
                {
                    context.Foods.Add(food);
                }
                else
                {
                    context.Foods.Update(food);
                }
                context.SaveChanges();
                return RedirectToAction("List");
            }
            else
            {
                ViewBag.Action =
                (food.FoodId == 0) ? "Add" : "Update";
                ViewBag.Foods =
                 context.Foods.OrderBy(g => g.Name).ToList();
                return View("AddUpdate", food);
            }
        }



        [HttpGet]
        public IActionResult Delete(int id)
        {
            var food = context.Foods.Find(id);
            return View(food);
        }

        [HttpPost]
        public IActionResult Delete(Food food)
        {
            context.Foods.Remove(food);
            context.SaveChanges();
            return RedirectToAction("Admin", "Home");
        }
    }
}
