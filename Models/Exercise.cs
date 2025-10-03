using Microsoft.AspNetCore.SignalR;
using System.ComponentModel.DataAnnotations;

namespace CalorieCalc.Models
{
    public class Exercise
    {
        [Required(ErrorMessage = "Please enter an exercise name")]
        [StringLength(100, ErrorMessage ="Exercise name too long!")]
        public string ExerciseName { get; set; }

        [Required]
        [Key]
        public int ExerciseId { get; set; }

        public double CalBurned { get; set; }

        [Required(ErrorMessage = "Please enter a valid heartrate")]
        [Range(10, 300, ErrorMessage ="Please enter a heartrate between 10-300 bpm")]
        public int HeartRate { get; set; }

        [Required(ErrorMessage = "Please enter a workout duration (minutes)")]
        [Range(1.0, 720.0, ErrorMessage = "Please enter a valid duration from 1-720 minutes")]
        public double Duration { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }


        public double? CalculateCalBurned(double UserWeight, int Age, char Gender, double Duration, int AvgHeartRate)
        {
            double? CalBurned = 0;

            if (Gender.Equals('M'))
            {
                CalBurned = Duration * (0.6309 * AvgHeartRate + 0.1988 * UserWeight + 0.2017 * Age - 55.0969) / 4.184;
            }

            if (Gender.Equals('F'))
            {
                CalBurned = Duration * (0.4472 * AvgHeartRate - 0.1263 * UserWeight + 0.074 * Age - 20.4022) / 4.184;
            }

            return CalBurned;
        }
    }
}
