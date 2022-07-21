using Microsoft.EntityFrameworkCore.Migrations;

namespace SManagement.DataAccess.Migrations
{
    public partial class SeedStafTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Stafs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Stafs",
                keyColumn: "Id",
                keyValue: 3,
                column: "Department",
                value: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Stafs",
                keyColumn: "Id",
                keyValue: 3,
                column: "Department",
                value: 1);

            migrationBuilder.InsertData(
                table: "Stafs",
                columns: new[] { "Id", "Department", "Email", "FirstName", "LastName" },
                values: new object[] { 2, 1, "tohirbekarzimurodov@gmail.com", "Tohirbe", "Arzimurodov" });
        }
    }
}
