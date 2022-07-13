using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Education.Persistence.Migrations
{
    public partial class EducationMigrationsInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    CursoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FechaPublicacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Precio = table.Column<decimal>(type: "decimal(14,2)", precision: 14, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.CursoId);
                });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "CursoId", "Descripcion", "FechaCreacion", "FechaPublicacion", "Precio", "Titulo" },
                values: new object[] { new Guid("b82d3154-768d-4017-8213-39f57602e23e"), "Curso de Unit Test para Net Core", new DateTime(2022, 7, 13, 8, 40, 11, 467, DateTimeKind.Local).AddTicks(5064), new DateTime(2024, 7, 13, 8, 40, 11, 467, DateTimeKind.Local).AddTicks(5064), 1000m, "Master en Unit Test con CQRS" });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "CursoId", "Descripcion", "FechaCreacion", "FechaPublicacion", "Precio", "Titulo" },
                values: new object[] { new Guid("d0b81b60-fc7a-4134-82f5-de3c3cca52e4"), "Curso de Java", new DateTime(2022, 7, 13, 8, 40, 11, 467, DateTimeKind.Local).AddTicks(5054), new DateTime(2024, 7, 13, 8, 40, 11, 467, DateTimeKind.Local).AddTicks(5054), 25m, "Master en Java Spring desde la raices" });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "CursoId", "Descripcion", "FechaCreacion", "FechaPublicacion", "Precio", "Titulo" },
                values: new object[] { new Guid("dc18f43c-58a7-4d70-92cd-45689b306a95"), "Curso de C# Basico", new DateTime(2022, 7, 13, 8, 40, 11, 467, DateTimeKind.Local).AddTicks(5019), new DateTime(2024, 7, 13, 8, 40, 11, 467, DateTimeKind.Local).AddTicks(5026), 56m, "C# desde cero hasta avanzado" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cursos");
        }
    }
}
