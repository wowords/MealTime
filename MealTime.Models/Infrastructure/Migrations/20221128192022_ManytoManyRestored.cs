using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MealTime.Models.Infrastructure.Migrations
{
    public partial class ManytoManyRestored : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meals_WeeklyMenus_WeeklyMenuId",
                table: "Meals");

            migrationBuilder.DropIndex(
                name: "IX_Meals_WeeklyMenuId",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "WeeklyMenuId",
                table: "Meals");

            migrationBuilder.CreateTable(
                name: "MealWeeklyMenu",
                columns: table => new
                {
                    MealsId = table.Column<int>(type: "int", nullable: false),
                    MenusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealWeeklyMenu", x => new { x.MealsId, x.MenusId });
                    table.ForeignKey(
                        name: "FK_MealWeeklyMenu_Meals_MealsId",
                        column: x => x.MealsId,
                        principalTable: "Meals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MealWeeklyMenu_WeeklyMenus_MenusId",
                        column: x => x.MenusId,
                        principalTable: "WeeklyMenus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MealWeeklyMenu_MenusId",
                table: "MealWeeklyMenu",
                column: "MenusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MealWeeklyMenu");

            migrationBuilder.AddColumn<int>(
                name: "WeeklyMenuId",
                table: "Meals",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Meals_WeeklyMenuId",
                table: "Meals",
                column: "WeeklyMenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_WeeklyMenus_WeeklyMenuId",
                table: "Meals",
                column: "WeeklyMenuId",
                principalTable: "WeeklyMenus",
                principalColumn: "Id");
        }
    }
}
