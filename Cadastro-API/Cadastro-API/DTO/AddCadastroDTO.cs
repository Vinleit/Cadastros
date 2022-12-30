using Cadastro_API.Models;

namespace Cadastro_API.DTO
{
    public class AddCadastroDTO
    {
        public string? Nome { get; set; }

        public string? data_nascimento { get; set; }

        public string? CPF { get; set; }
    }
}
