using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tablero_MVC.Migrations
{
    /// <inheritdoc />
    public partial class Segunda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tareas_Tareas_TareaIDTarea",
                table: "Tareas");

            migrationBuilder.DropIndex(
                name: "IX_Tareas_TareaIDTarea",
                table: "Tareas");

            migrationBuilder.DropColumn(
                name: "TareaIDTarea",
                table: "Tareas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TareaIDTarea",
                table: "Tareas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tareas_TareaIDTarea",
                table: "Tareas",
                column: "TareaIDTarea");

            migrationBuilder.AddForeignKey(
                name: "FK_Tareas_Tareas_TareaIDTarea",
                table: "Tareas",
                column: "TareaIDTarea",
                principalTable: "Tareas",
                principalColumn: "IDTarea");
        }
    }
}
