using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PosTech.PortFolio.Entities;

namespace PosTech.PortFolio.Repository.Sql.Configurations
{
    public class TransacaoConfiguration : IEntityTypeConfiguration<TransacaoEntity>
    {
        public void Configure(EntityTypeBuilder<TransacaoEntity> builder)
        {
            builder.ToTable("Transacao");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).HasColumnType("varchar(100)");
            builder.Property(u => u.DataCriacao).HasColumnType("DATETIME").IsRequired();
            builder.Property(u => u.Quantidade).HasColumnType("INT").IsRequired();
            builder.Property(u => u.Preco).HasColumnType("DECIMAL(18,2)").IsRequired();
            builder.Property(u => u.AtivoId).HasColumnType("varchar(100)").IsRequired();
            builder.Property(u => u.PortFolioId).HasColumnType("varchar(100)").IsRequired();
            builder.HasOne(t => t.Ativo).WithMany().HasPrincipalKey(u => u.Id);
            builder.HasOne(t => t.PortFolio).WithMany().HasPrincipalKey(u => u.Id);

        }
    }
}
