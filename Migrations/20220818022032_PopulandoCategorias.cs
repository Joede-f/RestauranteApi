using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestauranteNascimento.Migrations
{
    public partial class PopulandoCategorias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO categorias (NomeCat) VALUES ('tecnologia') ");
            migrationBuilder.Sql("INSERT INTO categorias (NomeCat) VALUES ('Limpeza') ");
            migrationBuilder.Sql("INSERT INTO categorias (NomeCat) VALUES ('Cosmeticos') ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from Categorias");
        }
    }
}
