using Domain.Groups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigurations
{
    public class ChargeStationEntityTypeConfiguration : IEntityTypeConfiguration<ChargeStation>
    {
        public void Configure(EntityTypeBuilder<ChargeStation> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).UseHiLo("chargestationseq");

            builder.Property<long>("GroupId").IsRequired();

            builder.HasMany(b => b.Connectors)
                .WithOne();

            builder.Metadata
                .FindNavigation(nameof(ChargeStation.Connectors))
                .SetPropertyAccessMode(PropertyAccessMode.Property);
        }
    }
}
