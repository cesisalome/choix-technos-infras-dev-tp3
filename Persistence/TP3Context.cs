using Choix_des_technos_et_infras_de_développement___TP3.Domain;
using Microsoft.EntityFrameworkCore;

namespace Choix_des_technos_et_infras_de_développement___TP3.Persistence
{
    public class TP3Context : DbContext
    {
        public DbSet<UserAccountEntity> Accounts { get; set; }

        public TP3Context(DbContextOptions<TP3Context> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
