using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiProduto.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class correcaoNomeTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "produto",
                newName: "descricao");

            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "marcas",
                newName: "descricao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "descricao",
                table: "produto",
                newName: "Descricao");

            migrationBuilder.RenameColumn(
                name: "descricao",
                table: "marcas",
                newName: "Descricao");
        }
    }
}
