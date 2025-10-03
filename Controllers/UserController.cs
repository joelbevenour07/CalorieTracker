using CalorieCalc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Linq;
using System.Reflection;

namespace CalorieCalc.Controllers
{
    public class UserController : Controller
    {
        private FoodContext context { get; set; }

        public UserController(FoodContext ctx)
        {
            context = ctx;
        }

        [HttpGet]

        public IActionResult UserHome(int id, User model)
        {
            ViewBag.UserId = id;
            ViewBag.UserName = context.Users.Find(id).UserName;
            ViewBag.UserHeight = context.Users.Find(id).UserHeight;
            ViewBag.UserAge = context.Users.Find(id).Age;
            ViewBag.UserWeight = context.Users.Find(id).UserWeight;
            ViewBag.UserGender = context.Users.Find(id).Gender;
            if (context.Users.Find(id).CalReq == null)
            {
                context.Users.Find(id).CalReq = model.CalculateCalReq(context.Users.Find(id).UserWeight, context.Users.Find(id).UserHeight, context.Users.Find(id).Age, context.Users.Find(id).Gender);
            }
            
            ViewBag.UserCalReq = context.Users.Find(id).CalReq;

            if (context.Users.Find(id).FatReq == null)
            {
                context.Users.Find(id).FatReq = model.CalculateFatReq((double)context.Users.Find(id).CalReq);
            }

            ViewBag.UserFatReq = context.Users.Find(id).FatReq;

            if (context.Users.Find(id).ChReq == null)
            {
                context.Users.Find(id).ChReq = model.SetCholesterolReq();
            }

            ViewBag.UserChReq = context.Users.Find(id).ChReq;

            if (context.Users.Find(id).CarbReq == null)
            {
                context.Users.Find(id).CarbReq = model.CaluclateCarbReq((double)context.Users.Find(id).CalReq);
            }

            ViewBag.UserCarbReq = context.Users.Find(id).CarbReq;

            if (context.Users.Find(id).ProteinReq == null)
            {
                context.Users.Find(id).ProteinReq = model.CalculateProteinReq((double)context.Users.Find(id).UserWeight);
            }

            ViewBag.UserProteinReq = context.Users.Find(id).ProteinReq;

            if (context.Users.Find(id).SodiumReq == null)
            {
                context.Users.Find(id).SodiumReq = model.SetSodiumReq();
            }

            ViewBag.UserSodiumReq = context.Users.Find(id).SodiumReq;

           
           
           var connection = context.Database.GetDbConnection();
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT FoodId FROM Foods";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                         System.Diagnostics.Debug.WriteLine($"FoodId Raw: {reader.GetValue(0)}");
                    }
                }
            }

            var foodEntity = context.Model.FindEntityType(typeof(CalorieCalc.Models.Food));
            var keys = foodEntity.FindPrimaryKey().Properties;

            foreach (var key in keys)
            {
                System.Diagnostics.Debug.WriteLine($"Key Name: {key.Name}, CLR Type: {key.ClrType}");
            }
            
            var foodEntity2 = context.Model.FindEntityType(typeof(CalorieCalc.Models.Food));
            System.Diagnostics.Debug.WriteLine($"Mapped table: {foodEntity2.GetTableName()}");

            //System.Diagnostics.Debug.WriteLine($"Debug message: {context.Foods.ToList()}");

            foreach (UserFoods userfoods in context.UserFoods)
            {
                System.Diagnostics.Debug.WriteLine($"My debug message: {context.Foods.Find(1)}");
                Food foods = context.Foods.Find(1);
                System.Diagnostics.Debug.WriteLine($"Debug message: {foods}");
                foreach (Food food in context.Foods)

                {
                    if (userfoods.UserId == id)
                    {
                        if (userfoods.FoodId == food.FoodId)
                        {
                            context.Users.Find(id).CalReq = model.CalculateNewReq((double)context.Users.Find(id).CalReq, food.Calories);
                            ViewBag.UserCalReq = context.Users.Find(id).CalReq;
                        }

                    }


                }
            }


            foreach (Exercise exercise in context.Exercises)
            {
                if (exercise.UserId == id)
                {
                    context.Users.Find(id).CalReq = model.CalculateNewlyAdded((double)context.Users.Find(id).CalReq, exercise.CalBurned);
                    ViewBag.UserCalReq = context.Users.Find(id).CalReq;
                }
            }



            foreach (UserFoods userfoods in context.UserFoods)
            {
                foreach (Food food in context.Foods)
                {
                    if (userfoods.UserId == id)
                    {
                        if (userfoods.FoodId == food.FoodId)
                        {
                            context.Users.Find(id).FatReq = model.CalculateNewReq((double)context.Users.Find(id).FatReq, food.Fats);
                            ViewBag.UserFatReq = context.Users.Find(id).FatReq;
                        }

                    }


                }
            }



            foreach (UserFoods userfoods in context.UserFoods)
            {
                foreach (Food food in context.Foods)
                {
                    if (userfoods.UserId == id)
                    {
                        if (userfoods.FoodId == food.FoodId)
                        {
                            context.Users.Find(id).ChReq = model.CalculateNewReq((double)context.Users.Find(id).ChReq, food.Cholesterol);
                            ViewBag.UserChReq = context.Users.Find(id).ChReq;
                        }

                    }


                }
            }


            foreach (UserFoods userfoods in context.UserFoods)
            {
                foreach (Food food in context.Foods)
                {
                    if (userfoods.UserId == id)
                    {
                        if (userfoods.FoodId == food.FoodId)
                        {
                            context.Users.Find(id).CarbReq = model.CalculateNewReq((double)context.Users.Find(id).CarbReq, food.Carbs);
                            ViewBag.UserCarbReq = context.Users.Find(id).CarbReq;
                        }

                    }


                }
            }


            context.Users.Find(id).ProteinReq = model.CalculateProteinReq((double)context.Users.Find(id).UserWeight);

            foreach (UserFoods userfoods in context.UserFoods)
            {
                foreach (Food food in context.Foods)
                {
                    if (userfoods.UserId == id)
                    {
                        if (userfoods.FoodId == food.FoodId)
                        {
                            context.Users.Find(id).ProteinReq = model.CalculateNewReq((double)context.Users.Find(id).ProteinReq, food.Protein);
                            ViewBag.UserProteinReq = context.Users.Find(id).ProteinReq;
                        }

                    }


                }
            }



            foreach (UserFoods userfoods in context.UserFoods)
            {
                foreach (Food food in context.Foods)
                {
                    if (userfoods.UserId == id)
                    {
                        if (userfoods.FoodId == food.FoodId)
                        {
                            context.Users.Find(id).SodiumReq = model.CalculateNewReq((double)context.Users.Find(id).SodiumReq, food.Sodium);
                            ViewBag.UserSodiumReq = context.Users.Find(id).SodiumReq;
                        }

                    }


                }
            }


            return View();
        }

        [HttpGet]
        public IActionResult AddUserFood(int id, User model)


        {

            var usermodel = new UserFoods();

            usermodel.foods = context.Foods.OrderBy(f => f.FoodId).ToList();

            usermodel.userfoods = context.UserFoods.OrderBy(uf => uf.UserId).ToList();



            ViewBag.UserId = id;
            ViewBag.UserName = context.Users.Find(id).UserName;
            ViewBag.UserHeight = context.Users.Find(id).UserHeight;
            ViewBag.UserAge = context.Users.Find(id).Age;
            ViewBag.UserWeight = context.Users.Find(id).UserWeight;
            ViewBag.UserGender = context.Users.Find(id).Gender;
            context.Users.Find(id).CalReq = model.CalculateCalReq(context.Users.Find(id).UserWeight, context.Users.Find(id).UserHeight, context.Users.Find(id).Age, context.Users.Find(id).Gender);
            ViewBag.UserCalReq = context.Users.Find(id).CalReq;

            context.Users.Find(id).FatReq = model.CalculateFatReq((double)context.Users.Find(id).CalReq);
            ViewBag.UserFatReq = context.Users.Find(id).FatReq;

            context.Users.Find(id).ChReq = model.SetCholesterolReq();
            ViewBag.UserChReq = context.Users.Find(id).ChReq;

            context.Users.Find(id).SodiumReq = model.SetSodiumReq();
            ViewBag.UserSodiumReq = context.Users.Find(id).SodiumReq;

            context.Users.Find(id).ProteinReq = model.CalculateProteinReq((double)context.Users.Find(id).UserWeight); 
            ViewBag.UserProteinReq = context.Users.Find(id).ProteinReq;

            context.Users.Find(id).CarbReq = model.CaluclateCarbReq((double)context.Users.Find(id).CalReq);
            ViewBag.UserCarbReq = context.Users.Find(id).CarbReq;
                
                foreach (UserFoods userfoods in context.UserFoods) {
                     foreach (Food food in context.Foods) {
                            if (userfoods.UserId == id)
                            {
                                if(userfoods.FoodId == food.FoodId)
                                {
                                    context.Users.Find(id).CalReq = model.CalculateNewReq((double)context.Users.Find(id).CalReq, food.Calories);
                                    ViewBag.UserCalReq = context.Users.Find(id).CalReq;
                                }
                            
                            }


                        }
                    }


            foreach (Exercise exercise in context.Exercises)
            {
                if (exercise.UserId == id)
                {
                    context.Users.Find(id).CalReq = model.CalculateNewlyAdded((double)context.Users.Find(id).CalReq, exercise.CalBurned);
                    ViewBag.UserCalReq = context.Users.Find(id).CalReq;
                }
            }



            foreach (UserFoods userfoods in context.UserFoods)
                {
                    foreach (Food food in context.Foods)
                    {
                        if (userfoods.UserId == id)
                        {
                            if (userfoods.FoodId == food.FoodId)
                            {
                                context.Users.Find(id).FatReq = model.CalculateNewReq((double)context.Users.Find(id).FatReq, food.Fats);
                                ViewBag.UserFatReq = context.Users.Find(id).FatReq;
                            }

                        }


                    }
                }
            


                foreach (UserFoods userfoods in context.UserFoods)
                {
                    foreach (Food food in context.Foods)
                    {
                        if (userfoods.UserId == id)
                        {
                            if (userfoods.FoodId == food.FoodId)
                            {
                                context.Users.Find(id).ChReq = model.CalculateNewReq((double)context.Users.Find(id).ChReq, food.Cholesterol);
                                ViewBag.UserChReq = context.Users.Find(id).ChReq;
                            }

                        }


                    }
                }
            

                foreach (UserFoods userfoods in context.UserFoods)
                {
                    foreach (Food food in context.Foods)
                    {
                        if (userfoods.UserId == id)
                        {
                            if (userfoods.FoodId == food.FoodId)
                            {
                                context.Users.Find(id).CarbReq = model.CalculateNewReq((double)context.Users.Find(id).CarbReq, food.Carbs);
                                ViewBag.UserCarbReq = context.Users.Find(id).CarbReq;
                            }

                        }


                    }
                }
            

                context.Users.Find(id).ProteinReq = model.CalculateProteinReq((double)context.Users.Find(id).UserWeight);

                foreach (UserFoods userfoods in context.UserFoods)
                {
                    foreach (Food food in context.Foods)
                    {
                        if (userfoods.UserId == id)
                        {
                            if (userfoods.FoodId == food.FoodId)
                            {
                                context.Users.Find(id).ProteinReq = model.CalculateNewReq((double)context.Users.Find(id).ProteinReq, food.Protein);
                                ViewBag.UserProteinReq = context.Users.Find(id).ProteinReq;
                            }

                        }


                    }
                }
            


                foreach (UserFoods userfoods in context.UserFoods)
                {
                    foreach (Food food in context.Foods)
                    {
                        if (userfoods.UserId == id)
                        {
                            if (userfoods.FoodId == food.FoodId)
                            {
                                context.Users.Find(id).SodiumReq = model.CalculateNewReq((double)context.Users.Find(id).SodiumReq, food.Sodium);
                                ViewBag.UserSodiumReq = context.Users.Find(id).SodiumReq;
                            }

                        }


                    }
                }
            


            return View(usermodel);
        }




        [HttpGet]
        public IActionResult AddToChosen(int userid, int foodid)
        {
            var userfood = new UserFoods();


            if (ModelState.IsValid)
            {

                context.Database.OpenConnection();
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.UserFoods ON");

                if (userfood.UserId == 0)
                {
                    
                    UserFoods LastElement = context.UserFoods.OrderByDescending(p => p.UserFoodId).FirstOrDefault();

                    if(LastElement == null)
                    {
                        int NextId = 1;
                        userfood.UserFoodId = NextId;
                        userfood.UserId = context.Users.Find(userid).UserId;
                        userfood.FoodId = context.Foods.Find(foodid).FoodId;
                        context.UserFoods.Add(userfood);
                    }
                    else
                    {
                        int NextId = LastElement.UserFoodId + 1;
                        userfood.UserFoodId = NextId;
                        userfood.UserId = context.Users.Find(userid).UserId;
                        userfood.FoodId = context.Foods.Find(foodid).FoodId;
                        context.UserFoods.Add(userfood);
                    }
                    

                }

                context.SaveChanges();
                return RedirectToAction("AddUserFood", new {id = userid});

            }
            else
            {
                ViewBag.Action =
                (userfood.UserId == 0) ? "Add" : "Update";
                ViewBag.UserFoods =
                 context.UserFoods.OrderBy(g => g.UserId).ToList();
                return View("AddUserFood", userfood);
            }
        }


        public IActionResult AddUserExercise(int id, User model)
        {

            var exerciseview = new ExerciseView();

            exerciseview.exercises = context.Exercises.OrderBy(e => e.ExerciseId).ToList();


            ViewBag.UserId = id;
            ViewBag.UserName = context.Users.Find(id).UserName;
            ViewBag.UserHeight = context.Users.Find(id).UserHeight;
            ViewBag.UserAge = context.Users.Find(id).Age;
            ViewBag.UserWeight = context.Users.Find(id).UserWeight;
            ViewBag.UserGender = context.Users.Find(id).Gender;

            context.Users.Find(id).CalReq = model.CalculateCalReq(context.Users.Find(id).UserWeight, context.Users.Find(id).UserHeight, context.Users.Find(id).Age, context.Users.Find(id).Gender);
            ViewBag.UserCalReq = context.Users.Find(id).CalReq;

            context.Users.Find(id).FatReq = model.CalculateFatReq((double)context.Users.Find(id).CalReq);
            ViewBag.UserFatReq = context.Users.Find(id).FatReq;

            context.Users.Find(id).ChReq = model.SetCholesterolReq();
            ViewBag.UserChReq = context.Users.Find(id).ChReq;

            context.Users.Find(id).SodiumReq = model.SetSodiumReq();
            ViewBag.UserSodiumReq = context.Users.Find(id).SodiumReq;

            context.Users.Find(id).ProteinReq = model.CalculateProteinReq((double)context.Users.Find(id).UserWeight);
            ViewBag.UserProteinReq = context.Users.Find(id).ProteinReq;

            context.Users.Find(id).CarbReq = model.CaluclateCarbReq((double)context.Users.Find(id).CalReq);
            ViewBag.UserCarbReq = context.Users.Find(id).CarbReq;

            foreach (UserFoods userfoods in context.UserFoods)
            {
                foreach (Food food in context.Foods)
                {
                    if (userfoods.UserId == id)
                    {
                        if (userfoods.FoodId == food.FoodId)
                        {
                            context.Users.Find(id).CalReq = model.CalculateNewReq((double)context.Users.Find(id).CalReq, food.Calories);
                            ViewBag.UserCalReq = context.Users.Find(id).CalReq;
                        }

                    }


                }
           
            }

            foreach(Exercise exercise in context.Exercises)
            {
                if(exercise.UserId == id)
                {
                    context.Users.Find(id).CalReq = model.CalculateNewlyAdded((double)context.Users.Find(id).CalReq, exercise.CalBurned);
                    ViewBag.UserCalReq = context.Users.Find(id).CalReq;
                }
            }


            foreach (UserFoods userfoods in context.UserFoods)
            {
                foreach (Food food in context.Foods)
                {
                    if (userfoods.UserId == id)
                    {
                        if (userfoods.FoodId == food.FoodId)
                        {
                            context.Users.Find(id).FatReq = model.CalculateNewReq((double)context.Users.Find(id).FatReq, food.Fats);
                            ViewBag.UserFatReq = context.Users.Find(id).FatReq;
                        }

                    }


                }
            }



            foreach (UserFoods userfoods in context.UserFoods)
            {
                foreach (Food food in context.Foods)
                {
                    if (userfoods.UserId == id)
                    {
                        if (userfoods.FoodId == food.FoodId)
                        {
                            context.Users.Find(id).ChReq = model.CalculateNewReq((double)context.Users.Find(id).ChReq, food.Cholesterol);
                            ViewBag.UserChReq = context.Users.Find(id).ChReq;
                        }

                    }


                }
            }


            foreach (UserFoods userfoods in context.UserFoods)
            {
                foreach (Food food in context.Foods)
                {
                    if (userfoods.UserId == id)
                    {
                        if (userfoods.FoodId == food.FoodId)
                        {
                            context.Users.Find(id).CarbReq = model.CalculateNewReq((double)context.Users.Find(id).CarbReq, food.Carbs);
                            ViewBag.UserCarbReq = context.Users.Find(id).CarbReq;
                        }

                    }


                }
            }


            context.Users.Find(id).ProteinReq = model.CalculateProteinReq((double)context.Users.Find(id).UserWeight);

            foreach (UserFoods userfoods in context.UserFoods)
            {
                foreach (Food food in context.Foods)
                {
                    if (userfoods.UserId == id)
                    {
                        if (userfoods.FoodId == food.FoodId)
                        {
                            context.Users.Find(id).ProteinReq = model.CalculateNewReq((double)context.Users.Find(id).ProteinReq, food.Protein);
                            ViewBag.UserProteinReq = context.Users.Find(id).ProteinReq;
                        }

                    }


                }
            }



            foreach (UserFoods userfoods in context.UserFoods)
            {
                foreach (Food food in context.Foods)
                {
                    if (userfoods.UserId == id)
                    {
                        if (userfoods.FoodId == food.FoodId)
                        {
                            context.Users.Find(id).SodiumReq = model.CalculateNewReq((double)context.Users.Find(id).SodiumReq, food.Sodium);
                            ViewBag.UserSodiumReq = context.Users.Find(id).SodiumReq;
                        }

                    }


                }
            }


            return View(exerciseview);
        }

       

        [HttpGet]
        public IActionResult Update(int exerciseid, double Weight, int Age, char Gender)
        {
            ViewBag.UserId = context.Exercises.Find(exerciseid).UserId;
            ViewBag.UserWeight = Weight;
            ViewBag.UserAge = Age;
            ViewBag.UserGender = Gender;
            ViewBag.Action = "Update";
            ViewBag.Exercises
            = context.Exercises.OrderBy(e => e.ExerciseName).ToList();
            var exercise = context.Exercises.Find(exerciseid);
            return View("AddExercise", exercise);

        }

        [HttpPost]
        public IActionResult Update(Exercise exercise, double Weight, int Age, char Gender, int id)
        {

            if (ModelState.IsValid)
            {

                if (exercise.ExerciseId == 0)
                {
                    context.Database.OpenConnection();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Exercises ON");

                    Exercise LastElement = context.Exercises.OrderByDescending(p => p.ExerciseId).FirstOrDefault();


                    if(LastElement == null || LastElement.ExerciseId == -1 )
                    {
                        int NextId = 1;
                        exercise.UserId = id;
                        exercise.ExerciseId = NextId;
                        exercise.CalBurned = (double)exercise.CalculateCalBurned(Weight, Age, Gender, exercise.Duration, exercise.HeartRate);
                        context.Exercises.Add(exercise);
                    }
                    else
                    {
                        int NextId = LastElement.ExerciseId + 1;
                        exercise.UserId = id;
                        exercise.ExerciseId = NextId;
                        exercise.CalBurned = (double)exercise.CalculateCalBurned(Weight, Age, Gender, exercise.Duration, exercise.HeartRate);
                        context.Exercises.Add(exercise);
                    }

                }

                else
                {
                    exercise.UserId = id;
                    
                    context.Exercises.Update(exercise);

                    exercise.CalBurned = (double)exercise.CalculateCalBurned(Weight, Age, Gender, exercise.Duration, exercise.HeartRate);
                }

                context.SaveChanges();
                return RedirectToAction("AddUserExercise", new { id = id});

            }
            else
            {
                ViewBag.Action =
                (exercise.ExerciseId == 0) ? "Add" : "Update";
                ViewBag.Exercises =
                 context.Exercises.OrderBy(g => g.ExerciseName).ToList();
                return View("AddExercise", exercise);
            }
        }

        [HttpGet]
        public IActionResult Add(int id, double Weight, int Age, char Gender)
        {
            ViewBag.UserId = id;
            ViewBag.UserWeight = Weight;
            ViewBag.UserAge = Age;
            ViewBag.UserGender = Gender;
            ViewBag.Action = "Add";
            ViewBag.Exercises
            = context.Exercises.OrderBy(g => g.ExerciseName).ToList();
            return View("AddExercise", new Exercise());
        }

        [HttpGet]
        public IActionResult DeleteUserFood(int id)
        {
            ViewBag.FoodId = context.UserFoods.Find(id).FoodId;
            ViewBag.UserId = context.UserFoods.Find(id).UserId;
            var userfood = context.UserFoods.Find(id);
            userfood.foods = context.Foods.OrderBy(f => f.Name).ToList();
            return View(userfood);
        }

        [HttpPost]
        public IActionResult DeleteUserFood(UserFoods userfood)
        {
            ViewBag.UserId = context.UserFoods.Find(userfood.UserFoodId).UserId;



            context.UserFoods.Remove(context.UserFoods.Find(userfood.UserFoodId));
            context.SaveChanges();
            return RedirectToAction("AddUserFood", new {id = ViewBag.UserId});
        }

        [HttpGet]
        public IActionResult DeleteUserExercise(int id)
        {
            ViewBag.ExerciseName = context.Exercises.Find(id).ExerciseName;
            ViewBag.ExerciseCals = context.Exercises.Find(id).CalBurned;
            ViewBag.ExerciseId = context.Exercises.Find(id).ExerciseId;
            ViewBag.UserId = context.Exercises.Find(id).UserId;
            var userexercise = context.Exercises.Find(id);
            return View(userexercise);
        }

        [HttpPost]
        public IActionResult DeleteUserExercise(Exercise exercise)
        {
            ViewBag.UserId = context.Exercises.Find(exercise.ExerciseId).UserId;

            context.Exercises.Remove(context.Exercises.Find(exercise.ExerciseId));
            context.SaveChanges();
            return RedirectToAction("AddUserExercise", new { id = ViewBag.UserId });
        }

    }
}
