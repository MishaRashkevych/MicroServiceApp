using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaAPIProject.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pizzas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Crust = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Speciality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsVeg = table.Column<bool>(type: "bit", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizzas", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "Id", "Crust", "Details", "IsVeg", "Name", "Picture", "Price", "Speciality" },
                values: new object[] { 1, "Meat", null, false, "Margherita", "", 20.0, "Plain" });

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "Id", "Crust", "Details", "IsVeg", "Name", "Picture", "Price", "Speciality" },
                values: new object[] { 2, "Standart", null, true, "Cheese N Corn", "", 25.0, "Cheezy" });

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "Id", "Crust", "Details", "IsVeg", "Name", "Picture", "Price", "Speciality" },
                values: new object[] { 3, "Cheezy", null, false, "Chicken Pepperoni", "", 20.0, "Spicy" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pizzas");
        }
    }
}
