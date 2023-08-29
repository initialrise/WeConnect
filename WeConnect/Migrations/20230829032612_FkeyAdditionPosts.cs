using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeConnect.Migrations
{
    public partial class FkeyAdditionPosts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Threads_ThreadsId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_ThreadsId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "ThreadsId",
                table: "Posts");

            migrationBuilder.AddColumn<int>(
                name: "ThreadID",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "Posts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_ThreadID",
                table: "Posts",
                column: "ThreadID");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserID",
                table: "Posts",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_UserID",
                table: "Posts",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Threads_ThreadID",
                table: "Posts",
                column: "ThreadID",
                principalTable: "Threads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_UserID",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Threads_ThreadID",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_ThreadID",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_UserID",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "ThreadID",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Posts");

            migrationBuilder.AddColumn<int>(
                name: "ThreadsId",
                table: "Posts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_ThreadsId",
                table: "Posts",
                column: "ThreadsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Threads_ThreadsId",
                table: "Posts",
                column: "ThreadsId",
                principalTable: "Threads",
                principalColumn: "Id");
        }
    }
}
