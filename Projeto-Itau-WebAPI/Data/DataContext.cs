using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Projeto_Itau_WebAPI.Model;

namespace Projeto_Itau_WebAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Conta> Contas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

    }
}