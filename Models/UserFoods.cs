using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace CalorieCalc.Models
{
    public class UserFoods
    {
        [Required]
        [Key]
        public int UserFoodId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int FoodId { get; set; }

        public Food Food { get; set; }

        public User User { get; set; }

        public List<Food> foods { get; set; }

        public List<UserFoods> userfoods { get; set; }


        



    }
}
