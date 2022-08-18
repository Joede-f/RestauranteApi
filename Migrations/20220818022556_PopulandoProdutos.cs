using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestauranteNascimento.Migrations
{
    public partial class PopulandoProdutos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO produtos (Nome,Descricao,Preco,CategoriaId) VALUES ('Notebook','um bom notebook acer',15,1) ");
            migrationBuilder.Sql("INSERT INTO produtos (Nome,Descricao,Preco,CategoriaId) VALUES ('Computador','Computador gamer',4500,1) ");
            migrationBuilder.Sql("INSERT INTO produtos (Nome,Descricao,Preco,CategoriaId) VALUES ('Monitor','Monitor de 27 polegadas',1500,1) ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from produtos");
        }
    }
}
