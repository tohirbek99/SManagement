using Microsoft.EntityFrameworkCore.Migrations;

namespace SManagement.DataAccess.Migrations
{
    public partial class Photo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Stafs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AddColumn<string>(
                name: "PhotoFillPath",
                table: "Stafs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Stafs",
                keyColumn: "Id",
                keyValue: 1,
                column: "Email",
                value: "tohirkarzimurodov@gmail.com");

            migrationBuilder.InsertData(
                table: "Stafs",
                columns: new[] { "Id", "Department", "Email", "FirstName", "LastName", "PhotoFillPath" },
                values: new object[] { 2, 2, "tohirbekarzimurodov@gmail.com", "Tohirbek", "Arzimurodov", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Stafs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "PhotoFillPath",
                table: "Stafs");

            migrationBuilder.UpdateData(
                table: "Stafs",
                keyColumn: "Id",
                keyValue: 1,
                column: "Email",
                value: "tohirbekarzimurodov@gmail.com");

            migrationBuilder.InsertData(
                table: "Stafs",
                columns: new[] { "Id", "Department", "Email", "FirstName", "LastName" },
                values: new object[] { 3, 2, "tohirbekarzimurodov@gmail.com", "Tohirbek", "Arzimurodov" });
        }
    }
}
