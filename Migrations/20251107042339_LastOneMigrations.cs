using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Veterinaria.Migrations
{
    /// <inheritdoc />
    public partial class LastOneMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Veterinarios_DocumentoIdentidad_Unique",
                table: "Veterinarios",
                column: "DocumentoIdentidad",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Veterinarios_Email_Unique",
                table: "Veterinarios",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL AND [Email] != ''");

            migrationBuilder.CreateIndex(
                name: "IX_Veterinarios_NumeroLicencia_Unique",
                table: "Veterinarios",
                column: "NumeroLicencia",
                unique: true,
                filter: "[NumeroLicencia] IS NOT NULL AND [NumeroLicencia] != ''");

            migrationBuilder.CreateIndex(
                name: "IX_Veterinarios_Telefono_Unique",
                table: "Veterinarios",
                column: "Telefono",
                unique: true,
                filter: "[Telefono] IS NOT NULL AND [Telefono] != ''");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_DocumentoIdentidad_Unique",
                table: "Clientes",
                column: "DocumentoIdentidad",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_Email_Unique",
                table: "Clientes",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL AND [Email] != ''");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_Telefono_Unique",
                table: "Clientes",
                column: "Telefono",
                unique: true,
                filter: "[Telefono] IS NOT NULL AND [Telefono] != ''");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Veterinarios_DocumentoIdentidad_Unique",
                table: "Veterinarios");

            migrationBuilder.DropIndex(
                name: "IX_Veterinarios_Email_Unique",
                table: "Veterinarios");

            migrationBuilder.DropIndex(
                name: "IX_Veterinarios_NumeroLicencia_Unique",
                table: "Veterinarios");

            migrationBuilder.DropIndex(
                name: "IX_Veterinarios_Telefono_Unique",
                table: "Veterinarios");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_DocumentoIdentidad_Unique",
                table: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_Email_Unique",
                table: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_Telefono_Unique",
                table: "Clientes");
        }
    }
}
