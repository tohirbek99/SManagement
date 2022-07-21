using Microsoft.EntityFrameworkCore.Migrations;

namespace SManagement.DataAccess.Migrations
{
    public partial class SeedStafTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Stafs",
                columns: new[] { "Id", "Department", "Email", "FirstName", "LastName" },
                values: new object[] { 1, 1, "tohirbekarzimurodov@gmail.com", "Tohir", "Arzimurodov" });

            migrationBuilder.InsertData(
                table: "Stafs",
                columns: new[] { "Id", "Department", "Email", "FirstName", "LastName" },
                values: new object[] { 2, 1, "tohirbekarzimurodov@gmail.com", "Tohirbe", "Arzimurodov" });

            migrationBuilder.InsertData(
                table: "Stafs",
                columns: new[] { "Id", "Department", "Email", "FirstName", "LastName" },
                values: new object[] { 3, 1, "tohirbekarzimurodov@gmail.com", "Tohirbek", "Arzimurodov" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Stafs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Stafs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Stafs",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
