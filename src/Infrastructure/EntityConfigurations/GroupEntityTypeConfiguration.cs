using Domain.Groups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigurations
{
    public class GroupEntityTypeConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).UseHiLo("groupseq");

            builder.OwnsOne(m => m.Capacity, e => { e.Property(e => e.Value).HasColumnName("Capacity").IsRequired(); });

            builder.HasMany(b => b.ChargeStations)
              .WithOne();

            builder.Metadata
               .FindNavigation(nameof(Group.ChargeStations))
               .SetPropertyAccessMode(PropertyAccessMode.Property);
        }
    }
}
