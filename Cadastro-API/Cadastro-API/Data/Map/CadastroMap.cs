using Cadastro_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cadastro_API.Data.Map
{
    public class CadastroMap : IEntityTypeConfiguration<CadastroModel>
    {
        public void Configure(EntityTypeBuilder<CadastroModel> builder)
        {
            builder.HasKey(x => x.cadastro_Id);
            builder.Property(x => x.Nome).IsRequired().HasColumnType("varchar").HasMaxLength(50);
            builder.Property(x => x.data_nascimento).IsRequired().HasColumnType("date");
            builder.Property(x => x.CPF).IsRequired().HasColumnType("varchar").HasMaxLength(12);
        }
    }
}
