using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CalorieCalc.Models
{
    public class User
    {
        [Required]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Please select user gender (M/F)")]
        
        public char Gender { get; set; }

        [Required(ErrorMessage = "Please enter user age")]
        [Range(1, 120, ErrorMessage = "Please enter an age between 1-120 years old")]
        public int Age { get; set; }

        [Required(ErrorMessage="Please enter a user name")]
        [StringLength(50, ErrorMessage = "Name is too long!")]
        public string UserName { get; set; }

        [Required(ErrorMessage="Please enter a user height (cm)")]
        [Range(20, 350, ErrorMessage = "Enter valid height in centimeters (20-350)")]
        public int UserHeight { get; set; }

        [Required(ErrorMessage ="Please enter a user weight (kg)")]
        [Range(10,500, ErrorMessage="Please enter a valid user weight in kilograms (10-500)")]
        public double UserWeight { get; set; }

        public double? CalReq { get; set; }

        public double? FatReq { get; set; }

        public double? ChReq { get; set; }
  
        public double? CarbReq { get; set; }

        public double? ProteinReq { get; set; }
 
        public double? SodiumReq { get; set; }

        public List<UserFoods> UserFoods { get; set; }




        public double? CalculateCalReq(double UserWeight, int UserHeight, int Age, char Gender)
        {
            double? CalRequired = 0;

            if (Gender.Equals('M'))
            {
                CalRequired = (66.5 + (13.75 * UserWeight) + (5.003 * UserHeight) - (6.75 * Age));
            }

            if(Gender.Equals('F'))
            {
                CalRequired = 655.1 + (9.563 * UserWeight) + (1.850 * UserHeight) - (4.676 * Age);
            }
            
            return CalRequired;
        }

        public double? CalculateProteinReq(double UserWeight)
        {
            double? ProteinRequired;

            ProteinRequired = (1.76 * UserWeight);

            return ProteinRequired;
        }

        public double? CaluclateCarbReq(double UserCalReq)
        {
            double? FatRequired;

            FatRequired = ((0.55 * UserCalReq) / 4);

            return FatRequired;
        }

        public double? CalculateFatReq(double UserCalReq)
        {
            double? FatRequired;

            FatRequired = ((0.30 * UserCalReq)/9);

            return FatRequired;
        }

        public double? SetSodiumReq()
        {
           double? SodiumRequired = 2300;

           return SodiumRequired;
        }

        public double? SetCholesterolReq()
        {
            double? ChRequired = 250;

            return ChRequired;
        }

        public double CalculateNewReq(double StartReq, double FoodNutrition)
        {
            double NewReq = StartReq;

            NewReq -= FoodNutrition;

            return NewReq;
        }

        public double CalculateNewlyAdded(double StartReq, double CalBurned)
        {
            double NewReq = StartReq;

            NewReq += CalBurned;

            return NewReq;
        }
    }
}
