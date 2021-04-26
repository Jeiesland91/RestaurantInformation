using Microsoft.EntityFrameworkCore.Migrations;

namespace RestaurantInfo.Migrations
{
    public partial class InitialDatabaseCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chefs",
                columns: table => new
                {
                    ChefId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 100, nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chefs", x => x.ChefId);
                });

            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    RestaurantId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Cuisine = table.Column<string>(maxLength: 50, nullable: false),
                    ChefId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.RestaurantId);
                    table.ForeignKey(
                        name: "FK_Restaurants_Chefs_ChefId",
                        column: x => x.ChefId,
                        principalTable: "Chefs",
                        principalColumn: "ChefId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Chefs",
                columns: new[] { "ChefId", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "John", "Montgomery" },
                    { 2, "Hannah", "Smith" },
                    { 3, "Jackson", "Brown" },
                    { 4, "Wilson", "Thomas" },
                    { 5, "Kelly", "Hughes" }
                });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "RestaurantId", "ChefId", "Cuisine", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Steakhouse", "Mastro's" },
                    { 2, 1, "Healthy", "True Food Kitchen" },
                    { 5, 2, "Mexican", "Habanero's" },
                    { 6, 2, "Sushi", "Sushi Roku" },
                    { 9, 3, "American", "White Chocolate Grill" },
                    { 10, 3, "American", "Tommy Bahamas Grill" },
                    { 3, 4, "Seafood", "Oceans Grill" },
                    { 4, 4, "Mexican", "SOL Mexican Grill" },
                    { 7, 5, "Sushi", "Sakana Sushi & Grill" },
                    { 8, 5, "Japanese", "Roka Akor" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_ChefId",
                table: "Restaurants",
                column: "ChefId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Restaurants");

            migrationBuilder.DropTable(
                name: "Chefs");
        }
    }
}
