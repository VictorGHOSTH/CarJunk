using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarJunk.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AutosPiezas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutosPiezas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AutosReacondicionados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Motor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kilometraje = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutosReacondicionados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Desperdicios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AutoPiezasId = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCierre = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desperdicios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Desperdicios_AutosPiezas_AutoPiezasId",
                        column: x => x.AutoPiezasId,
                        principalTable: "AutosPiezas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Piezas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AutoPiezasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Piezas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Piezas_AutosPiezas_AutoPiezasId",
                        column: x => x.AutoPiezasId,
                        principalTable: "AutosPiezas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VentasPiezas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PiezaId = table.Column<int>(type: "int", nullable: false),
                    CantidadVendida = table.Column<int>(type: "int", nullable: false),
                    FechaVenta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PrecioVenta = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VentasPiezas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VentasPiezas_Piezas_PiezaId",
                        column: x => x.PiezaId,
                        principalTable: "Piezas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Desperdicios_AutoPiezasId",
                table: "Desperdicios",
                column: "AutoPiezasId");

            migrationBuilder.CreateIndex(
                name: "IX_Piezas_AutoPiezasId",
                table: "Piezas",
                column: "AutoPiezasId");

            migrationBuilder.CreateIndex(
                name: "IX_VentasPiezas_PiezaId",
                table: "VentasPiezas",
                column: "PiezaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutosReacondicionados");

            migrationBuilder.DropTable(
                name: "Desperdicios");

            migrationBuilder.DropTable(
                name: "VentasPiezas");

            migrationBuilder.DropTable(
                name: "Piezas");

            migrationBuilder.DropTable(
                name: "AutosPiezas");
        }
    }
}
