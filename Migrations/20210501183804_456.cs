using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.Migrations
{
    public partial class _456 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Steden",
                columns: new[] { "StadId", "Naam", "Provincie" },
                values: new object[] { 1, "Kortrijk", "West-Vlaanderen" });

            migrationBuilder.InsertData(
                table: "Steden",
                columns: new[] { "StadId", "Naam", "Provincie" },
                values: new object[] { 2, "Brugge", "West-Vlaanderen" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Steden",
                keyColumn: "StadId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Steden",
                keyColumn: "StadId",
                keyValue: 2);
        }
    }
}
