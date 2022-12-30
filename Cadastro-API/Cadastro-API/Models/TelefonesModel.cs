using System.Text.Json.Serialization;

namespace Cadastro_API.Models
{
    public class TelefonesModel
    {
        public int telefone_Id { get; set; }
        
        public string? Telefone { get; set; }

        [JsonIgnore] //Corrigir o erro de "object cycle"
        public CadastroModel cadastro { get; set;}
        
        public int cadastroID { get; set; }
    }
}
