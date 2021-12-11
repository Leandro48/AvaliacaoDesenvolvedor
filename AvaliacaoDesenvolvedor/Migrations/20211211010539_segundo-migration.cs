using Microsoft.EntityFrameworkCore.Migrations;

namespace AvaliacaoDesenvolvedor.Migrations
{
    public partial class segundomigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Telefone_Contatos_ContatoId",
                table: "Telefone");

            migrationBuilder.AlterColumn<int>(
                name: "ContatoId",
                table: "Telefone",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Telefone_Contatos_ContatoId",
                table: "Telefone",
                column: "ContatoId",
                principalTable: "Contatos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Telefone_Contatos_ContatoId",
                table: "Telefone");

            migrationBuilder.AlterColumn<int>(
                name: "ContatoId",
                table: "Telefone",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Telefone_Contatos_ContatoId",
                table: "Telefone",
                column: "ContatoId",
                principalTable: "Contatos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
