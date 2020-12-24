using Application.Common.Interfaces;
using Domain.Groups;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Persistence
{
    public class SmartChargingDbContext : DbContext, ISmartChargingDbContext
    {
        public DbSet<Group> Groups { get; set; }

        public SmartChargingDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
