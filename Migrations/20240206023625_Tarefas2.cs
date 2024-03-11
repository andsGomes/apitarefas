using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TarefasAPI.Migrations
{
    /// <inheritdoc />
    public partial class Tarefas2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isCompleted",
                table: "tarefas");

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "tarefas",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "tarefas");

            migrationBuilder.AddColumn<bool>(
                name: "isCompleted",
                table: "tarefas",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}
