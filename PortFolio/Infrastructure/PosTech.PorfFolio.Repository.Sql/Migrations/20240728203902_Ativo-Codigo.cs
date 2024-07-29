using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PosTech.PortFolio.Repository.Sql.Migrations
{
    /// <inheritdoc />
    public partial class AtivoCodigo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Codigo",
                table: "Ativo",
                type: "VARCHAR(15)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(5)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Codigo",
                table: "Ativo",
                type: "VARCHAR(5)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(15)");
        }
    }
}
