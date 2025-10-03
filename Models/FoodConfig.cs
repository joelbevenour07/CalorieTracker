using CalorieCalc.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Reflection.Emit;

namespace CalorieCalc.Models
{
    internal class FoodConfig : IEntityTypeConfiguration<Food>
    {
        public void Configure(EntityTypeBuilder<Food> entity)
        {

            entity.HasOne(m => m.Meal)
                .WithMany(f => f.Foods);



            entity.HasOne(m => m.Meal)
                .WithMany(f => f.Foods)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasData(
                new Food
                {
                    FoodId = 1,
                    Name = "Chicken Breast",
                    Calories = 180,
                    FoodServing = 170,
                    Carbs = 0,
                    Fats = 2,
                    Cholesterol = 100,
                    Protein = 39,
                    Sodium = 110,
                    MealId = 3
                },

                new Food
                {
                    FoodId = 2,
                    Name = "Steak",
                    Calories = 679,
                    FoodServing = 251,
                    Carbs = 0,
                    Fats = 48,
                    Cholesterol = 196,
                    Protein = 62,
                    Sodium = 146,
                    MealId = 3
                },
                new Food
                {
                    FoodId = 3,
                    Name = "Cheerios",
                    Calories = 140,
                    FoodServing = 39,
                    Carbs = 29,
                    Fats = 2.5,
                    Cholesterol = 0,
                    Protein = 5,
                    Sodium = 190,
                    MealId = 1
                },

                new Food
                {
                    FoodId = 4,
                    Name = "1% Milk",
                    Calories = 103,
                    FoodServing = 244,
                    Carbs = 12,
                    Fats = 2.4,
                    Cholesterol = 12,
                    Protein = 8,
                    Sodium = 107,
                    MealId = 1
                },

                new Food
                {
                    FoodId = 5,
                    Name = "Potato (Large)",
                    Calories = 283,
                    FoodServing = 369,
                    Carbs = 64,
                    Fats = 0.3,
                    Cholesterol = 0,
                    Protein = 7,
                    Sodium = 22,
                    MealId = 3
                },

                new Food
                {
                    FoodId = 6,
                    Name = "Broccoli",
                    Calories = 50,
                    FoodServing = 148,
                    Carbs = 10,
                    Fats = 0.5,
                    Cholesterol = 0,
                    Protein = 4.2,
                    Sodium = 49,
                    MealId = 3
                },

                new Food
                {
                    FoodId = 7,
                    Name = "Bagel",
                    Calories = 245,
                    FoodServing = 98,
                    Carbs = 48,
                    Fats = 1.5,
                    Cholesterol = 0,
                    Protein = 10,
                    Sodium = 430,
                    MealId = 1
                },

                new Food
                {
                    FoodId = 8,
                    Name = "Pineapple",
                    Calories = 82,
                    FoodServing = 165,
                    Carbs = 22,
                    Fats = 0.2,
                    Cholesterol = 0,
                    Protein = 0.9,
                    Sodium = 2,
                    MealId = 4
                },

                new Food
                {
                    FoodId = 9,
                    Name = "White Rice",
                    Calories = 206,
                    FoodServing = 158,
                    Carbs = 45,
                    Fats = 0.4,
                    Cholesterol = 0,
                    Protein = 4.3,
                    Sodium = 2,
                    MealId = 2
                },

                new Food
                {
                    FoodId = 10,
                    Name = "Chocolate Chip Cookie",
                    Calories = 160,
                    FoodServing = 32,
                    Carbs = 18,
                    Fats = 9,
                    Cholesterol = 22,
                    Protein = 1.8,
                    Sodium = 110,
                    MealId = 4
                }

                );
        }
    }
}
