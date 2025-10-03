using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CalorieCalc.Models
{
    public class Food
    {
        [Required]
        [Key]
        public int FoodId { get; set; }

        [Required(ErrorMessage = "Please enter food name")]
        [StringLength(50, ErrorMessage = "Please enter shorter food name!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter food's calories")]
        [Range(0, 2000, ErrorMessage = "Food serving calories must be between 1-2000")]
        public int Calories { get; set; }

        [Required(ErrorMessage = "Please enter food's carbohydrates (grams)")]
        public double Carbs { get; set; }

        [Required(ErrorMessage = "Please enter food's fats (grams)")]
        public double Fats { get; set; }

        [Required(ErrorMessage = "Please enter food's cholesterol (mg)")]
        public double Cholesterol { get; set; }

        [Required(ErrorMessage = "Please enter food's protein (grams)")]
        public double Protein { get; set; }

        [Required(ErrorMessage = "Please enter food's carbohydrates (mg)")]
        public double Sodium { get; set; }

        [Required(ErrorMessage = "Please enter food's serving size (grams)")]
        public int FoodServing { get; set; }

        [ForeignKey("Meal")]
        public int MealId { get; set; }

        public Meal Meal { get; set; }
        // public List<Food> foods { get; set; }
       
        //public List<Food> foods { get; set; }

    }


}

