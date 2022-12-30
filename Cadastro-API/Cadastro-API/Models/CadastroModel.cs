namespace Cadastro_API.Models
{
    public class CadastroModel
    {
        public int cadastro_Id { get; set; }
        
        public string? Nome { get; set; }
        
        public DateTime? data_nascimento { get; set; }
        
        public string? CPF { get; set; }
        
        public ICollection<TelefonesModel>? telefones { get; set; }
    }
}
