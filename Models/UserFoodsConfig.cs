using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CalorieCalc.Models
{
    internal class UserFoodsConfig : IEntityTypeConfiguration<UserFoods>
    {
        public void Configure(EntityTypeBuilder<UserFoods> entity)
        {

            entity.HasKey(uf => new {uf.UserFoodId});
            
            entity.HasOne(uf => uf.Food);

            entity.HasOne(u => u.User)
                .WithMany(uf => uf.UserFoods);


            entity.HasData(
            new UserFoods
            {
                UserFoodId = 2,
                UserId = -1,
                FoodId = 1
            }
            );

        }

    }
}
