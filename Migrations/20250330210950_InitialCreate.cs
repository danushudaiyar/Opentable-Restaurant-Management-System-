using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OpenTable.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Metropolises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Metropolises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MetropolisId = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriceRange = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CuisineStyle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OpenHours = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Restaurants_Metropolises_MetropolisId",
                        column: x => x.MetropolisId,
                        principalTable: "Metropolises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Metropolises",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "New York" },
                    { 2, "Los Angeles" },
                    { 3, "Chicago" },
                    { 4, "Houston" },
                    { 5, "Miami" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Role", "Username" },
                values: new object[,]
                {
                    { 1, "admin@opentable.com", "admin", "admin" },
                    { 2, "manager@opentable.com", "manager", "manager" }
                });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Id", "Address", "CuisineStyle", "MetropolisId", "Name", "OpenHours", "PriceRange" },
                values: new object[,]
                {
                    { 1, "12 E 12th St, New York, NY", "American", 1, "Gotham Bar & Grill", "11:00-14:00,17:00-22:00", "$$$" },
                    { 2, "22706 Pacific Coast Hwy, Malibu, CA", "Japanese", 2, "Nobu Malibu", "17:00-21:30", "$$$$" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Metropolises_Name",
                table: "Metropolises",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_MetropolisId",
                table: "Restaurants",
                column: "MetropolisId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Restaurants");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Metropolises");
        }
    }
}
