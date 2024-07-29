using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PosTech.PortFolio.Repository.Sql.Migrations
{
    /// <inheritdoc />
    public partial class ClienteBaseNome : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Senha",
                table: "Cliente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Senha",
                table: "Cliente",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
