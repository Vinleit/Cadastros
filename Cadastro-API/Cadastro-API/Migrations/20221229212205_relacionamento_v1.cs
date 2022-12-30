using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadastroAPI.Migrations
{
    /// <inheritdoc />
    public partial class relacionamentov1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "data_nascimento",
                table: "Cadastros",
                type: "date",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldMaxLength: 10);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "data_nascimento",
                table: "Cadastros",
                type: "varchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");
        }
    }
}
