using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaRestaurant.Migrations
{
    public partial class AddFoodAndMenuModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MenuCategories",
                columns: table => new
                {
                    MenuCategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuCategories", x => x.MenuCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    MenuItemId = table.Column<Guid>(nullable: false),
                    MenuCategoryId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 150, nullable: false),
                    Desc = table.Column<string>(maxLength: 450, nullable: false),
                    Pref = table.Column<string>(maxLength: 150, nullable: true),
                    Charge = table.Column<double>(nullable: false),
                    Calories = table.Column<int>(nullable: false),
                    CaloriesFat = table.Column<int>(nullable: false),
                    TFat = table.Column<int>(nullable: false),
                    SatFat = table.Column<int>(nullable: false),
                    TransFat = table.Column<int>(nullable: false),
                    Choles = table.Column<int>(nullable: false),
                    Sodium = table.Column<int>(nullable: false),
                    TCarbs = table.Column<int>(nullable: false),
                    Fiber = table.Column<int>(nullable: false),
                    Sugar = table.Column<int>(nullable: false),
                    Protein = table.Column<int>(nullable: false),
                    Ingredients = table.Column<string>(maxLength: 1000, nullable: true),
                    Al_Gluten = table.Column<bool>(nullable: false),
                    Al_Milk = table.Column<bool>(nullable: false),
                    Al_Wheat = table.Column<bool>(nullable: false),
                    Al_Eggs = table.Column<bool>(nullable: false),
                    Al_Fish = table.Column<bool>(nullable: false),
                    Al_Shellfish = table.Column<bool>(nullable: false),
                    Al_TreeNuts = table.Column<bool>(nullable: false),
                    Al_Peanuts = table.Column<bool>(nullable: false),
                    Al_Soy = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.MenuItemId);
                    table.ForeignKey(
                        name: "FK_MenuCategoryId",
                        column: x => x.MenuCategoryId,
                        principalTable: "MenuCategories",
                        principalColumn: "MenuCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FoodOptionSets",
                columns: table => new
                {
                    FoodOptionSetId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 150, nullable: false),
                    MenuItemId = table.Column<Guid>(nullable: false),
                    Charge = table.Column<double>(nullable: false),
                    Calories = table.Column<int>(nullable: false),
                    CaloriesFat = table.Column<int>(nullable: false),
                    TFat = table.Column<int>(nullable: false),
                    SatFat = table.Column<int>(nullable: false),
                    TransFat = table.Column<int>(nullable: false),
                    Choles = table.Column<int>(nullable: false),
                    Sodium = table.Column<int>(nullable: false),
                    TCarbs = table.Column<int>(nullable: false),
                    Fiber = table.Column<int>(nullable: false),
                    Sugar = table.Column<int>(nullable: false),
                    Protein = table.Column<int>(nullable: false),
                    Ingredients = table.Column<string>(maxLength: 1000, nullable: true),
                    Al_Gluten = table.Column<bool>(nullable: false),
                    Al_Milk = table.Column<bool>(nullable: false),
                    Al_Wheat = table.Column<bool>(nullable: false),
                    Al_Eggs = table.Column<bool>(nullable: false),
                    Al_Fish = table.Column<bool>(nullable: false),
                    Al_Shellfish = table.Column<bool>(nullable: false),
                    Al_TreeNuts = table.Column<bool>(nullable: false),
                    Al_Peanuts = table.Column<bool>(nullable: false),
                    Al_Soy = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodOptionSets", x => x.FoodOptionSetId);
                    table.ForeignKey(
                        name: "FK_MenuItemId",
                        column: x => x.MenuItemId,
                        principalTable: "MenuItems",
                        principalColumn: "MenuItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FoodOptions",
                columns: table => new
                {
                    FoodOptionId = table.Column<Guid>(nullable: false),
                    FoodOptionSetId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 150, nullable: false),
                    Description = table.Column<string>(maxLength: 400, nullable: true),
                    Charge = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodOptions", x => x.FoodOptionId);
                    table.ForeignKey(
                        name: "FK_FoodOptionSetId",
                        column: x => x.FoodOptionSetId,
                        principalTable: "FoodOptionSets",
                        principalColumn: "FoodOptionSetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodOptions_FoodOptionSetId",
                table: "FoodOptions",
                column: "FoodOptionSetId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodOptionSets_MenuItemId",
                table: "FoodOptionSets",
                column: "MenuItemId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_MenuCategoryId",
                table: "MenuItems",
                column: "MenuCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodOptions");

            migrationBuilder.DropTable(
                name: "FoodOptionSets");

            migrationBuilder.DropTable(
                name: "MenuItems");

            migrationBuilder.DropTable(
                name: "MenuCategories");
        }
    }
}
