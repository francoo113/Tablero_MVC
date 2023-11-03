using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tablero_MVC.Migrations
{
    /// <inheritdoc />
    public partial class NuevoMas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IDUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Institucion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IDUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Tableros",
                columns: table => new
                {
                    IDTablero = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tableros", x => x.IDTablero);
                    table.ForeignKey(
                        name: "FK_Tableros_Usuarios_IDUsuario",
                        column: x => x.IDUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IDUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tareas",
                columns: table => new
                {
                    IDTarea = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstadoTarea = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TableroIDTablero = table.Column<int>(type: "int", nullable: true),
                    TareaIDTarea = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tareas", x => x.IDTarea);
                    table.ForeignKey(
                        name: "FK_Tareas_Tableros_TableroIDTablero",
                        column: x => x.TableroIDTablero,
                        principalTable: "Tableros",
                        principalColumn: "IDTablero");
                    table.ForeignKey(
                        name: "FK_Tareas_Tareas_TareaIDTarea",
                        column: x => x.TareaIDTarea,
                        principalTable: "Tareas",
                        principalColumn: "IDTarea");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tableros_IDUsuario",
                table: "Tableros",
                column: "IDUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Tareas_TableroIDTablero",
                table: "Tareas",
                column: "TableroIDTablero");

            migrationBuilder.CreateIndex(
                name: "IX_Tareas_TareaIDTarea",
                table: "Tareas",
                column: "TareaIDTarea");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tareas");

            migrationBuilder.DropTable(
                name: "Tableros");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
