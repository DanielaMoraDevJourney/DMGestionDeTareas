using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DMGestionDeTareas.Migrations
{
    /// <inheritdoc />
    public partial class Inicio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DMCategoria",
                columns: table => new
                {
                    DMCategoriaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DMNombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DMDescripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DMTareaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DMCategoria", x => x.DMCategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "DMPrioridad",
                columns: table => new
                {
                    DMPrioridadId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DMNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DMDescripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DMTareaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DMPrioridad", x => x.DMPrioridadId);
                });

            migrationBuilder.CreateTable(
                name: "DMTarea",
                columns: table => new
                {
                    DMTareaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DMTitulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DMDescripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DMFechaVencimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DMPrioridadId = table.Column<int>(type: "int", nullable: false),
                    DMCategoriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DMTarea", x => x.DMTareaId);
                    table.ForeignKey(
                        name: "FK_DMTarea_DMCategoria_DMCategoriaId",
                        column: x => x.DMCategoriaId,
                        principalTable: "DMCategoria",
                        principalColumn: "DMCategoriaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DMTarea_DMPrioridad_DMPrioridadId",
                        column: x => x.DMPrioridadId,
                        principalTable: "DMPrioridad",
                        principalColumn: "DMPrioridadId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DMCategoria_DMTareaId",
                table: "DMCategoria",
                column: "DMTareaId");

            migrationBuilder.CreateIndex(
                name: "IX_DMPrioridad_DMTareaId",
                table: "DMPrioridad",
                column: "DMTareaId");

            migrationBuilder.CreateIndex(
                name: "IX_DMTarea_DMCategoriaId",
                table: "DMTarea",
                column: "DMCategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_DMTarea_DMPrioridadId",
                table: "DMTarea",
                column: "DMPrioridadId");

            migrationBuilder.AddForeignKey(
                name: "FK_DMCategoria_DMTarea_DMTareaId",
                table: "DMCategoria",
                column: "DMTareaId",
                principalTable: "DMTarea",
                principalColumn: "DMTareaId");

            migrationBuilder.AddForeignKey(
                name: "FK_DMPrioridad_DMTarea_DMTareaId",
                table: "DMPrioridad",
                column: "DMTareaId",
                principalTable: "DMTarea",
                principalColumn: "DMTareaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DMCategoria_DMTarea_DMTareaId",
                table: "DMCategoria");

            migrationBuilder.DropForeignKey(
                name: "FK_DMPrioridad_DMTarea_DMTareaId",
                table: "DMPrioridad");

            migrationBuilder.DropTable(
                name: "DMTarea");

            migrationBuilder.DropTable(
                name: "DMCategoria");

            migrationBuilder.DropTable(
                name: "DMPrioridad");
        }
    }
}
