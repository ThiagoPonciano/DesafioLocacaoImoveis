using DesafioLocacaoImoveis.Api.Data.Map;
using DesafioLocacaoImoveis.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DesafioLocacaoImoveis.Api.Data
{
    public class LocacaoImoveisDbContext : DbContext
    {
        public LocacaoImoveisDbContext(DbContextOptions<LocacaoImoveisDbContext> options)
            : base(options)
        {
        }

        public DbSet<Imoveis> Imoveis { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ImovelMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
