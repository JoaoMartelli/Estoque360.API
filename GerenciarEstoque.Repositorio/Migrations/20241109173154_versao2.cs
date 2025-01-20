using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciarEstoque.Repositorio.Migrations
{
    public partial class versao2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cor",
                table: "Categorias");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cor",
                table: "Categorias",
                type: "nvarchar(7)",
                maxLength: 7,
                nullable: false,
                defaultValue: "");
        }
    }
}
