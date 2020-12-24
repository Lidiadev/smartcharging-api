using Domain.Groups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigurations
{
    public class ConnectorEntityTypeConfiguration : IEntityTypeConfiguration<Connector>
    {
        public void Configure(EntityTypeBuilder<Connector> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).UseHiLo("connectorseq");

            builder.OwnsOne(m => m.MaxCurrent, e => { e.Property(e => e.Value).HasColumnName("MaxCurrent").IsRequired(); });
            //builder.Property<long>("ChargeStationId").IsRequired();
        }
    }
}
