using Cadastro_API.Data.Map;
using Cadastro_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Cadastro_API.Data
{
    public class SistemaCadastrosDBContext : DbContext
    {
        public SistemaCadastrosDBContext(DbContextOptions<SistemaCadastrosDBContext> options) : base(options) 
        { 
        }


        public DbSet<CadastroModel> Cadastros { get; set; } //CadastroModel representa Cadastros no SQL
        public DbSet<TelefonesModel> Telefones { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CadastroMap());
            modelBuilder.ApplyConfiguration(new TelefonesMap());
            base.OnModelCreating(modelBuilder);
        }

    }
}
