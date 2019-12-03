using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PagueVeloz.Teste.Infra.Data.Mappings;

namespace PagueVeloz.Teste.Infra.Data
{
    public class PagueVelozContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public PagueVelozContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("pagueVeloz"));
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmpresaMap());
            modelBuilder.ApplyConfiguration(new FornecedorMap());
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}