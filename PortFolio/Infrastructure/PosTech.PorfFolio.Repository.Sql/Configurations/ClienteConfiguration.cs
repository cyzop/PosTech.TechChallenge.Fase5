using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PosTech.PortFolio.Entities;

namespace PosTech.PortFolio.Repository.Sql.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<ClienteEntity>
    {
        public void Configure(EntityTypeBuilder<ClienteEntity> builder)
        {
            builder.ToTable("Cliente");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).HasColumnType("varchar(100)");
            builder.Property(u => u.DataCriacao).HasColumnType("DATETIME").IsRequired();
            builder.Property(u => u.Nome).HasColumnType("VARCHAR(150)").IsRequired();
            builder.Property(u => u.Email).HasColumnType("VARCHAR(150)").IsRequired();
        }
    }
}
