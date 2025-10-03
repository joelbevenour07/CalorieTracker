using CalorieCalc.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Linq;

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
            var data = new FoodUserListView
            {
                ActiveMealType = activeMealType,
                meals = context.Meals.ToList(),
                foods = context.Foods.ToList()
                
            };

            IQueryable<Food> query = context.Foods;
            if (activeMealType != "all")
                query = query.Where(
                    t => t.Meal.MealType.ToLower() == activeMealType.ToLower());

            data.foods = query.ToList();

            return View(data);
        }

        [HttpGet]

        public IActionResult Foods(string activeMealType = "all")
        {

            var data = new FoodUserListView
            {
                ActiveMealType = activeMealType,
                meals = context.Meals.ToList(),
                foods = context.Foods.ToList()

            };

            IQueryable<Food> query = context.Foods;
            if (activeMealType != "all")
                query = query.Where(
                    t => t.Meal.MealType.ToLower() == activeMealType.ToLower());

            data.foods = query.ToList();

            return View(data);

        }

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
