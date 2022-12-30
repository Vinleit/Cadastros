using Cadastro_API.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Cadastro_API.Data.Map
{
    public class TelefonesMap : IEntityTypeConfiguration<TelefonesModel>
    {
        public void Configure(EntityTypeBuilder<TelefonesModel> builder)
        {
            builder.HasKey(t => t.telefone_Id);
            builder.Property(t => t.Telefone).IsRequired().HasColumnType("varchar").HasMaxLength(15);
        }
    }
}

