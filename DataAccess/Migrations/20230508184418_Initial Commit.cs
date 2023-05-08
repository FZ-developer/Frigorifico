using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class InitialCommit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Frigorificos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RazonSocial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CUIT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoriaIVA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CantidadVacas = table.Column<int>(type: "int", nullable: false),
                    Caja = table.Column<decimal>(type: "DECIMAL(9,2)", nullable: false),
                    DeudasACobrar = table.Column<decimal>(type: "DECIMAL(9,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frigorificos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Campos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdFrigorifico = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CantidadVacas = table.Column<int>(type: "int", nullable: false),
                    DeudaAPagar = table.Column<decimal>(type: "DECIMAL(11,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Campos_Frigorificos_IdFrigorifico",
                        column: x => x.IdFrigorifico,
                        principalTable: "Frigorificos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdFrigorifico = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SaldoACobrar = table.Column<decimal>(type: "DECIMAL(9,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.id);
                    table.ForeignKey(
                        name: "FK_Clientes_Frigorificos_IdFrigorifico",
                        column: x => x.IdFrigorifico,
                        principalTable: "Frigorificos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdFrigorifico = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StockPorKg = table.Column<int>(type: "int", nullable: false),
                    PrecioPorKg = table.Column<decimal>(type: "DECIMAL(9,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Productos_Frigorificos_IdFrigorifico",
                        column: x => x.IdFrigorifico,
                        principalTable: "Frigorificos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FacturasCompra",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaCompra = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdCampo = table.Column<int>(type: "int", nullable: false),
                    IdFrigorifico = table.Column<int>(type: "int", nullable: false),
                    TipoDePago = table.Column<int>(type: "int", nullable: false),
                    CantidadVacas = table.Column<int>(type: "int", nullable: false),
                    PrecioVaca = table.Column<decimal>(type: "DECIMAL(7,2)", nullable: false),
                    PrecioTotalCompra = table.Column<decimal>(type: "DECIMAL(9,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacturasCompra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FacturasCompra_Campos_IdCampo",
                        column: x => x.IdCampo,
                        principalTable: "Campos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FacturasCompra_Frigorificos_IdFrigorifico",
                        column: x => x.IdFrigorifico,
                        principalTable: "Frigorificos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FacturasVenta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaVenta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdFrigorifico = table.Column<int>(type: "int", nullable: false),
                    TipoDePago = table.Column<int>(type: "int", nullable: false),
                    Vendedor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    PrecioTotalVenta = table.Column<decimal>(type: "DECIMAL(9,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacturasVenta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FacturasVenta_Clientes_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Clientes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FacturasVenta_Frigorificos_IdFrigorifico",
                        column: x => x.IdFrigorifico,
                        principalTable: "Frigorificos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetallesFactura",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdFacturaVenta = table.Column<int>(type: "int", nullable: false),
                    IdProducto = table.Column<int>(type: "int", nullable: false),
                    CantidadPorKg = table.Column<int>(type: "int", nullable: false),
                    PrecioTotalProducto = table.Column<decimal>(type: "DECIMAL(9,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallesFactura", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetallesFactura_FacturasVenta_IdFacturaVenta",
                        column: x => x.IdFacturaVenta,
                        principalTable: "FacturasVenta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DetallesFactura_Productos_IdProducto",
                        column: x => x.IdProducto,
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Campos_IdFrigorifico",
                table: "Campos",
                column: "IdFrigorifico");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_IdFrigorifico",
                table: "Clientes",
                column: "IdFrigorifico");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesFactura_IdFacturaVenta",
                table: "DetallesFactura",
                column: "IdFacturaVenta");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesFactura_IdProducto",
                table: "DetallesFactura",
                column: "IdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_FacturasCompra_IdCampo",
                table: "FacturasCompra",
                column: "IdCampo");

            migrationBuilder.CreateIndex(
                name: "IX_FacturasCompra_IdFrigorifico",
                table: "FacturasCompra",
                column: "IdFrigorifico");

            migrationBuilder.CreateIndex(
                name: "IX_FacturasVenta_IdCliente",
                table: "FacturasVenta",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_FacturasVenta_IdFrigorifico",
                table: "FacturasVenta",
                column: "IdFrigorifico");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_IdFrigorifico",
                table: "Productos",
                column: "IdFrigorifico");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetallesFactura");

            migrationBuilder.DropTable(
                name: "FacturasCompra");

            migrationBuilder.DropTable(
                name: "FacturasVenta");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Campos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Frigorificos");
        }
    }
}
