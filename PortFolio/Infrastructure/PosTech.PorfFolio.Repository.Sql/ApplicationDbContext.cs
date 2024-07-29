using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PosTech.PortFolio.Entities;

namespace PosTech.PortFolio.Repository.Sql
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ApplicationDbContext()
        {
        }
        public ApplicationDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<ClienteEntity> Cliente { get; set; }
        public DbSet<AtivoEntity> Ativo { get; set; }
        public DbSet<PortFolioEntity> PortFolio { get; set; }
        public DbSet<TransacaoEntity> Transacao { get; set; }


        //configura qual banco de dados se utilizará
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string str = _configuration?.GetSection("ConnectionStrings:ConnectionString")?.Value;
                optionsBuilder.UseSqlServer(str);
                optionsBuilder.UseLazyLoadingProxies();
            }
        }
        //informa a implementaão a ser utilizada
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //A) pode usar  definindo as classes que estão com as configurações individualmbnete
            //modelBuilder.ApplyConfiguration(new AtivoConfiguration());
            //modelBuilder.ApplyConfiguration(new ClienteConfiguration());
            //modelBuilder.ApplyConfiguration(new TransacaoConfiguration());
            //modelBuilder.ApplyConfiguration(new PortFolioConfiguration());

            //B) OU  configurar para pegar a configuration no assembly
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        }
    }
}