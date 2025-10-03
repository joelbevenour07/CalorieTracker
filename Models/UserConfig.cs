using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
namespace CalorieCalc.Models
{
    internal class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {

            entity.HasData(
            new User
            {
                UserId = -1,
                UserHeight = 175,
                UserWeight = 90,
                UserName = "John Doe",
                Gender = 'M',
                Age = 25
            },

            new User
            {
                UserId = -2,
                UserHeight = 161,
                UserWeight = 77,
                UserName = "Jane Doe",
                Gender = 'F',
                Age = 25
            }
            );

        }
    }
}
