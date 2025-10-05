namespace CalorieCalc.ViewModels
{
    public class FoodDto
    {
        public int FoodId { get; set; }
        public string Name { get; set; }
        public int Calories { get; set; }
        public double Carbs { get; set; }
        public double Fats { get; set; }
        public double Cholesterol { get; set; }
        public double Protein { get; set; }
        public double Sodium { get; set; }
        public int FoodServing { get; set; }

        public int MealId { get; set; }
        public string MealType { get; set; }
    }
}