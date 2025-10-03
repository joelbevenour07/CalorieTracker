using Microsoft.EntityFrameworkCore.Migrations;

namespace CalorieCalc.Migrations
{
    public partial class Rebuild : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    MealId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MealType = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.MealId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gender = table.Column<string>(nullable: false),
                    Age = table.Column<int>(nullable: false),
                    UserName = table.Column<string>(maxLength: 50, nullable: false),
                    UserHeight = table.Column<int>(nullable: false),
                    UserWeight = table.Column<double>(nullable: false),
                    CalReq = table.Column<double>(nullable: true),
                    FatReq = table.Column<double>(nullable: true),
                    ChReq = table.Column<double>(nullable: true),
                    CarbReq = table.Column<double>(nullable: true),
                    ProteinReq = table.Column<double>(nullable: true),
                    SodiumReq = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    ExerciseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExerciseName = table.Column<string>(maxLength: 100, nullable: false),
                    CalBurned = table.Column<double>(nullable: false),
                    HeartRate = table.Column<int>(nullable: false),
                    Duration = table.Column<double>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.ExerciseId);
                    table.ForeignKey(
                        name: "FK_Exercises_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserFoods",
                columns: table => new
                {
                    UserFoodId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    FoodId = table.Column<int>(nullable: false),
                    UserFoodsUserFoodId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFoods", x => x.UserFoodId);
                    table.ForeignKey(
                        name: "FK_UserFoods_UserFoods_UserFoodsUserFoodId",
                        column: x => x.UserFoodsUserFoodId,
                        principalTable: "UserFoods",
                        principalColumn: "UserFoodId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserFoods_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    FoodId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Calories = table.Column<int>(nullable: false),
                    Carbs = table.Column<double>(nullable: false),
                    Fats = table.Column<double>(nullable: false),
                    Cholesterol = table.Column<double>(nullable: false),
                    Protein = table.Column<double>(nullable: false),
                    Sodium = table.Column<double>(nullable: false),
                    FoodServing = table.Column<int>(nullable: false),
                    MealId = table.Column<int>(nullable: false),
                    UserFoodsUserFoodId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.FoodId);
                    table.ForeignKey(
                        name: "FK_Foods_Meals_MealId",
                        column: x => x.MealId,
                        principalTable: "Meals",
                        principalColumn: "MealId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Foods_UserFoods_UserFoodsUserFoodId",
                        column: x => x.UserFoodsUserFoodId,
                        principalTable: "UserFoods",
                        principalColumn: "UserFoodId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Meals",
                columns: new[] { "MealId", "MealType" },
                values: new object[,]
                {
                    { 1, "Breakfast" },
                    { 2, "Lunch" },
                    { 3, "Dinner" },
                    { 4, "Snack" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Age", "CalReq", "CarbReq", "ChReq", "FatReq", "Gender", "ProteinReq", "SodiumReq", "UserHeight", "UserName", "UserWeight" },
                values: new object[,]
                {
                    { -1, 25, null, null, null, null, "M", null, null, 175, "John Doe", 90.0 },
                    { -2, 25, null, null, null, null, "F", null, null, 161, "Jane Doe", 77.0 }
                });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "ExerciseId", "CalBurned", "Duration", "ExerciseName", "HeartRate", "UserId" },
                values: new object[] { -1, 0.0, 0.0, "Nothing", 0, -1 });

            migrationBuilder.InsertData(
                table: "Foods",
                columns: new[] { "FoodId", "Calories", "Carbs", "Cholesterol", "Fats", "FoodServing", "MealId", "Name", "Protein", "Sodium", "UserFoodsUserFoodId" },
                values: new object[,]
                {
                    { 3, 140, 29.0, 0.0, 2.5, 39, 1, "Cheerios", 5.0, 190.0, null },
                    { 4, 103, 12.0, 12.0, 2.3999999999999999, 244, 1, "1% Milk", 8.0, 107.0, null },
                    { 7, 245, 48.0, 0.0, 1.5, 98, 1, "Bagel", 10.0, 430.0, null },
                    { 9, 206, 45.0, 0.0, 0.40000000000000002, 158, 2, "White Rice", 4.2999999999999998, 2.0, null },
                    { 1, 180, 0.0, 100.0, 2.0, 170, 3, "Chicken Breast", 39.0, 110.0, null },
                    { 2, 679, 0.0, 196.0, 48.0, 251, 3, "Steak", 62.0, 146.0, null },
                    { 5, 283, 64.0, 0.0, 0.29999999999999999, 369, 3, "Potato (Large)", 7.0, 22.0, null },
                    { 6, 50, 10.0, 0.0, 0.5, 148, 3, "Broccoli", 4.2000000000000002, 49.0, null },
                    { 8, 82, 22.0, 0.0, 0.20000000000000001, 165, 4, "Pineapple", 0.90000000000000002, 2.0, null },
                    { 10, 160, 18.0, 22.0, 9.0, 32, 4, "Chocolate Chip Cookie", 1.8, 110.0, null }
                });

            migrationBuilder.InsertData(
                table: "UserFoods",
                columns: new[] { "UserFoodId", "FoodId", "UserFoodsUserFoodId", "UserId" },
                values: new object[] { 2, 1, null, -1 });

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_UserId",
                table: "Exercises",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Foods_MealId",
                table: "Foods",
                column: "MealId");

            migrationBuilder.CreateIndex(
                name: "IX_Foods_UserFoodsUserFoodId",
                table: "Foods",
                column: "UserFoodsUserFoodId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFoods_FoodId",
                table: "UserFoods",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFoods_UserFoodsUserFoodId",
                table: "UserFoods",
                column: "UserFoodsUserFoodId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFoods_UserId",
                table: "UserFoods",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFoods_Foods_FoodId",
                table: "UserFoods",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "FoodId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFoods_Users_UserId",
                table: "UserFoods");

            migrationBuilder.DropForeignKey(
                name: "FK_Foods_Meals_MealId",
                table: "Foods");

            migrationBuilder.DropForeignKey(
                name: "FK_Foods_UserFoods_UserFoodsUserFoodId",
                table: "Foods");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Meals");

            migrationBuilder.DropTable(
                name: "UserFoods");

            migrationBuilder.DropTable(
                name: "Foods");
        }
    }
}
