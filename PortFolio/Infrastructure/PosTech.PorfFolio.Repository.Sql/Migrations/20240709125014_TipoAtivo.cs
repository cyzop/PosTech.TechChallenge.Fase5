using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PosTech.PortFolio.Repository.Sql.Migrations
{
    /// <inheritdoc />
    public partial class TipoAtivo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Tipo",
                table: "Ativo",
                type: "VARCHAR(12)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(10)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Tipo",
                table: "Ativo",
                type: "VARCHAR(10)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(12)");
        }
    }
}
