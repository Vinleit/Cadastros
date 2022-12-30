using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadastroAPI.Migrations
{
    /// <inheritdoc />
    public partial class relacionamentos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cadastros",
                columns: table => new
                {
                    cadastroId = table.Column<int>(name: "cadastro_Id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    datanascimento = table.Column<string>(name: "data_nascimento", type: "varchar(10)", maxLength: 10, nullable: false),
                    CPF = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cadastros", x => x.cadastroId);
                });

            migrationBuilder.CreateTable(
                name: "Telefones",
                columns: table => new
                {
                    telefoneId = table.Column<int>(name: "telefone_Id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Telefone = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    cadastroID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefones", x => x.telefoneId);
                    table.ForeignKey(
                        name: "FK_Telefones_Cadastros_cadastroID",
                        column: x => x.cadastroID,
                        principalTable: "Cadastros",
                        principalColumn: "cadastro_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Telefones_cadastroID",
                table: "Telefones",
                column: "cadastroID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Telefones");

            migrationBuilder.DropTable(
                name: "Cadastros");
        }
    }
}
