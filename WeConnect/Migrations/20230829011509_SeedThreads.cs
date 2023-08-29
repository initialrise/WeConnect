using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeConnect.Migrations
{
    public partial class SeedThreads : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ThreadSubscribedId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Threads",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "CSIT" });

            migrationBuilder.InsertData(
                table: "Threads",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "BCA" });

            migrationBuilder.InsertData(
                table: "Threads",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "BIM" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ThreadSubscribedId",
                table: "AspNetUsers",
                column: "ThreadSubscribedId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Threads_ThreadSubscribedId",
                table: "AspNetUsers",
                column: "ThreadSubscribedId",
                principalTable: "Threads",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Threads_ThreadSubscribedId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ThreadSubscribedId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "Threads",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Threads",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Threads",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "ThreadSubscribedId",
                table: "AspNetUsers");
        }
    }
}
