using back.src.ProAtividade.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using ProAtividade.Data.Mappings;

namespace back.src.ProAtividade.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Atividade> Atividades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AtividadeMap()); 
        }
    }
}