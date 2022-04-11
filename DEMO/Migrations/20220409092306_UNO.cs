using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DEMO.Migrations
{
    public partial class UNO : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "JB");

            migrationBuilder.CreateTable(
                name: "DEPARTAMENTO",
                schema: "JB",
                columns: table => new
                {
                    ID_DEPARTAMENTO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    N_DEPARTAMENTO = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEPARTAMENTO", x => x.ID_DEPARTAMENTO);
                });

            migrationBuilder.CreateTable(
                name: "EMPLEADOS",
                schema: "JB",
                columns: table => new
                {
                    ID_EMPLEADO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    N_EMPLEADO = table.Column<string>(type: "varchar(250)", nullable: false),
                    A_PATERNO = table.Column<string>(type: "varchar(250)", nullable: false),
                    A_MATERNO = table.Column<string>(type: "varchar(250)", nullable: false),
                    F_NACIMIENTO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SUELDO = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ID_DEPARTAMENTO = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPLEADOS", x => x.ID_EMPLEADO);
                    table.ForeignKey(
                        name: "FK_EMPLEADOS_DEPARTAMENTO_ID_DEPARTAMENTO",
                        column: x => x.ID_DEPARTAMENTO,
                        principalSchema: "JB",
                        principalTable: "DEPARTAMENTO",
                        principalColumn: "ID_DEPARTAMENTO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DEPARTAMENTO_ID_DEPARTAMENTO",
                schema: "JB",
                table: "DEPARTAMENTO",
                column: "ID_DEPARTAMENTO",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EMPLEADOS_ID_DEPARTAMENTO",
                schema: "JB",
                table: "EMPLEADOS",
                column: "ID_DEPARTAMENTO");

            migrationBuilder.CreateIndex(
                name: "IX_EMPLEADOS_ID_EMPLEADO",
                schema: "JB",
                table: "EMPLEADOS",
                column: "ID_EMPLEADO",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EMPLEADOS",
                schema: "JB");

            migrationBuilder.DropTable(
                name: "DEPARTAMENTO",
                schema: "JB");
        }
    }
}
