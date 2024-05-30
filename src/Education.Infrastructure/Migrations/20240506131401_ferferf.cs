using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Education.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ferferf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_AspNetUsers_UserId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_UserId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Courses");

            migrationBuilder.AddColumn<string>(
                name: "UserModelId",
                table: "Courses",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_UserModelId",
                table: "Courses",
                column: "UserModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_AspNetUsers_UserModelId",
                table: "Courses",
                column: "UserModelId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_AspNetUsers_UserModelId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_UserModelId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "UserModelId",
                table: "Courses");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Courses",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_UserId",
                table: "Courses",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_AspNetUsers_UserId",
                table: "Courses",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
