using CalorieCalc.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Reflection.Emit;

namespace CalorieCalc.Models
{
    internal class MealConfig : IEntityTypeConfiguration<Meal>
    {
        public void Configure(EntityTypeBuilder<Meal> entity)
        {

            entity.HasData(
            new Meal
            {
                MealId = 1,
                MealType = "Breakfast"
            },

            new Meal
            {
                MealId = 2,
                MealType = "Lunch"
            },

            new Meal
            {
                MealId = 3,
                MealType = "Dinner"
            },

            new Meal
            {
                MealId = 4,
                MealType = "Snack"
            }
            );

        }
    }
}
