using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SchoolPrimaProject.Migrations
{
    /// <inheritdoc />
    public partial class sample : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Schools",
                columns: new[] { "School_Id", "School_Address", "School_Name" },
                values: new object[,]
                {
                    { 1, "Kurunegala", "Maliyadeva  College" },
                    { 2, "Panadura", "President s College" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Schools",
                keyColumn: "School_Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Schools",
                keyColumn: "School_Id",
                keyValue: 2);
        }
    }
}
