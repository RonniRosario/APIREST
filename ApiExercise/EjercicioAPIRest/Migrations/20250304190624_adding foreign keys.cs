using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EjercicioAPIRest.Migrations
{
    /// <inheritdoc />
    public partial class addingforeignkeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Categorias_CategoriaIdCategoria",
                table: "Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Proveedor_ProveedorIdProveedor",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Productos_CategoriaIdCategoria",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Productos_ProveedorIdProveedor",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "CategoriaIdCategoria",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "ProveedorIdProveedor",
                table: "Productos");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_IdCategoria",
                table: "Productos",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_IdProveedor",
                table: "Productos",
                column: "IdProveedor");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Categorias_IdCategoria",
                table: "Productos",
                column: "IdCategoria",
                principalTable: "Categorias",
                principalColumn: "IdCategoria",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Proveedor_IdProveedor",
                table: "Productos",
                column: "IdProveedor",
                principalTable: "Proveedor",
                principalColumn: "IdProveedor",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Categorias_IdCategoria",
                table: "Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Proveedor_IdProveedor",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Productos_IdCategoria",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Productos_IdProveedor",
                table: "Productos");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaIdCategoria",
                table: "Productos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProveedorIdProveedor",
                table: "Productos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Productos_CategoriaIdCategoria",
                table: "Productos",
                column: "CategoriaIdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_ProveedorIdProveedor",
                table: "Productos",
                column: "ProveedorIdProveedor");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Categorias_CategoriaIdCategoria",
                table: "Productos",
                column: "CategoriaIdCategoria",
                principalTable: "Categorias",
                principalColumn: "IdCategoria",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Proveedor_ProveedorIdProveedor",
                table: "Productos",
                column: "ProveedorIdProveedor",
                principalTable: "Proveedor",
                principalColumn: "IdProveedor",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
