using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeConnect.Migrations
{
    public partial class ThreadKeyinUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Threads_ThreadSubscribedId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "ThreadSubscribedId",
                table: "AspNetUsers",
                newName: "ThreadID");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_ThreadSubscribedId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_ThreadID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Threads_ThreadID",
                table: "AspNetUsers",
                column: "ThreadID",
                principalTable: "Threads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Threads_ThreadID",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "ThreadID",
                table: "AspNetUsers",
                newName: "ThreadSubscribedId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_ThreadID",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_ThreadSubscribedId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Threads_ThreadSubscribedId",
                table: "AspNetUsers",
                column: "ThreadSubscribedId",
                principalTable: "Threads",
                principalColumn: "Id");
        }
    }
}
