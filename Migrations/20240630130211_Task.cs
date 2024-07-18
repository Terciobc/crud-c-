using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tasks.Migrations
{
    /// <inheritdoc />
    public partial class Task : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "user_id",
                table: "Tasks",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_user_id",
                table: "Tasks",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Users_user_id",
                table: "Tasks",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Users_user_id",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_user_id",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "Tasks");
        }
    }
}
