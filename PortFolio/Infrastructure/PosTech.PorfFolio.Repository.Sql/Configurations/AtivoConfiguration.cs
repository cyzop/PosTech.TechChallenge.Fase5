using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PosTech.PortFolio.Entities;

namespace PosTech.PortFolio.Repository.Sql.Configurations
{
    public class AtivoConfiguration : IEntityTypeConfiguration<AtivoEntity>
    {
        public void Configure(EntityTypeBuilder<AtivoEntity> builder)
        {
            builder.ToTable("Ativo");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).HasColumnType("varchar(100)");
            builder.Property(u => u.DataCriacao).HasColumnType("DATETIME").IsRequired();
            builder.Property(u => u.Tipo).HasColumnType("VARCHAR(12)").IsRequired();
            builder.Property(u => u.Codigo).HasColumnType("VARCHAR(5)").IsRequired();
        }
    }
}
