using DesafioLocacaoImoveis.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioLocacaoImoveis.Api.Data.Map
{
    public class ImovelMap : IEntityTypeConfiguration<Imoveis>
    {
        public void Configure(EntityTypeBuilder<Imoveis> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Cep).IsRequired().HasMaxLength(8);
            builder.Property(x => x.Adress).HasMaxLength(256);
            builder.Property(x => x.Neighborhood).HasMaxLength(100); 
            builder.Property(x => x.City).HasMaxLength(100); 
            builder.Property(x => x.State).HasMaxLength(2); 
            builder.Property(x => x.Value);
            builder.Property(x => x.Status);
        }
    }
}
