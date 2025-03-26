using DesafioLocacaoImoveis.Api.Data.Map;
using DesafioLocacaoImoveis.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DesafioLocacaoImoveis.Api.Data
{
    public class LocacaoImoveisDbContext : DbContext
    {
        private readonly IConfiguration _configuracaoAppSettings;
        public LocacaoImoveisDbContext(IConfiguration configuracaoAppSettings)
        {
            _configuracaoAppSettings = configuracaoAppSettings;
        }

        public DbSet<Imoveis> Imoveis { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ImovelMap());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var stringConexao = _configuracaoAppSettings.GetConnectionString("DataBase")?.ToString();
                if (!string.IsNullOrEmpty(stringConexao))
                {
                    optionsBuilder.UseMySql(stringConexao, ServerVersion.AutoDetect(stringConexao));
                }
            }
        }
    }
}
