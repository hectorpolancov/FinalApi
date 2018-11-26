using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class M4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Vehiculos_VehiculosId",
                table: "Clientes");

            migrationBuilder.AlterColumn<int>(
                name: "VehiculosId",
                table: "Clientes",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Vehiculos_VehiculosId",
                table: "Clientes",
                column: "VehiculosId",
                principalTable: "Vehiculos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Vehiculos_VehiculosId",
                table: "Clientes");

            migrationBuilder.AlterColumn<int>(
                name: "VehiculosId",
                table: "Clientes",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Vehiculos_VehiculosId",
                table: "Clientes",
                column: "VehiculosId",
                principalTable: "Vehiculos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
