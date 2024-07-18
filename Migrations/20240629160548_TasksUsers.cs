using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tasks.Migrations
{
    /// <inheritdoc />
    public partial class TasksUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Users",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "DateUpgraded",
                table: "Users",
                newName: "data_upgrade");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "Users",
                newName: "data_create");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Tasks",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Tasks",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Tasks",
                newName: "descricao");

            migrationBuilder.RenameColumn(
                name: "DateUpgraded",
                table: "Tasks",
                newName: "data_update");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "Tasks",
                newName: "data_criacao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "password",
                table: "Users",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "data_upgrade",
                table: "Users",
                newName: "DateUpgraded");

            migrationBuilder.RenameColumn(
                name: "data_create",
                table: "Users",
                newName: "DateCreated");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "Tasks",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Tasks",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "descricao",
                table: "Tasks",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "data_update",
                table: "Tasks",
                newName: "DateUpgraded");

            migrationBuilder.RenameColumn(
                name: "data_criacao",
                table: "Tasks",
                newName: "DateCreated");
        }
    }
}
