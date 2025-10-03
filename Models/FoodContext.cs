using Microsoft.AspNetCore.Builder;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CalorieCalc.Models
{
    public class FoodContext : DbContext
    {
            public FoodContext(DbContextOptions<FoodContext> options)
            : base(options)
            { }

            public DbSet<Food> Foods { get; set; }
            public DbSet<User> Users { get; set; }
            public DbSet<Meal> Meals { get; set; }
            public DbSet<Exercise> Exercises { get; set; }
            public DbSet<UserFoods> UserFoods { get; set; }
        protected override void OnModelCreating(
            ModelBuilder modelBuilder)
            {
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new MealConfig());
            modelBuilder.ApplyConfiguration(new UserFoodsConfig());
            modelBuilder.ApplyConfiguration(new FoodConfig());
            modelBuilder.ApplyConfiguration(new ExerciseConfig());

        }
        }
    }

