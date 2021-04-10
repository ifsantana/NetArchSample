using Microsoft.EntityFrameworkCore;
using NetSampleArch.Adapters.SQLServer.DataContexts.Interfaces;
using NetSampleArch.Infra.CrossCutting.Configuration;
using System.Linq;

namespace NetSampleArch.Adapters.EFCore.DataContexts
{
    public abstract class DefaultContext : DbContext, IDbContext
    {
        protected Configuration Configuration { get; }

        protected DefaultContext(Configuration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.Restrict;

            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            OnConfiguringInternal(optionsBuilder);
        }
        protected abstract void OnConfiguringInternal(DbContextOptionsBuilder optionsBuilder);

    }
}
