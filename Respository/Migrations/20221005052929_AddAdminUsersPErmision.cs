using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class AddAdminUsersPErmision : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Security",
                table: "Activities",
                columns: new[] { "Id", "Description" },
                values: new object[] { "AddAdminUsers", "Add new players" });

            migrationBuilder.InsertData(
                schema: "Security",
                table: "RolsActivity",
                columns: new[] { "ActivityId", "RolId" },
                values: new object[] { "AddAdminUsers", "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Security",
                table: "RolsActivity",
                keyColumns: new[] { "ActivityId", "RolId" },
                keyValues: new object[] { "AddAdminUsers", "Admin" });

            migrationBuilder.DeleteData(
                schema: "Security",
                table: "Activities",
                keyColumn: "Id",
                keyValue: "AddAdminUsers");
        }
    }
}
