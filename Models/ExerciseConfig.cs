using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CalorieCalc.Models
{
    internal class ExerciseConfig : IEntityTypeConfiguration<Exercise>
    {
        public void Configure(EntityTypeBuilder<Exercise> entity)
        {

            entity.HasData(
            new Exercise
            {
                ExerciseId = -1,
                ExerciseName = "Nothing",
                CalBurned = 0,
                HeartRate = 0,
                Duration = 0,
                UserId = -1
            }

            );

        }
    }
}
