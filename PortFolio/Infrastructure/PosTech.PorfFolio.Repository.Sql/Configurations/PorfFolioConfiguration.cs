using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PosTech.PortFolio.Entities;

namespace PosTech.PortFolio.Repository.Sql.Configurations
{
    public class PortFolioConfiguration : IEntityTypeConfiguration<PortFolioEntity>
    {
        public void Configure(EntityTypeBuilder<PortFolioEntity> builder)
        {
            builder.ToTable("PortFolio");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).HasColumnType("VARCHAR(100)");
            builder.Property(u => u.Nome).HasColumnType("VARCHAR(150)").IsRequired();
            builder.Property(u => u.Descricao).HasColumnType("VARCHAR(250)").IsRequired();
            builder.Property(u => u.DataCriacao).HasColumnType("DATETIME").IsRequired();
            builder.Property(u => u.ClienteId).HasColumnType("VARCHAR(100)").IsRequired();
            builder.HasOne(p => p.Cliente)
                .WithMany()
                .HasPrincipalKey(u => u.Id);
        }
    }
}
