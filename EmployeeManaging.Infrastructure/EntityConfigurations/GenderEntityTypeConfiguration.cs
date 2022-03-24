using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EmployeeManaging.Domain.EmployeeAggregate;

namespace EmployeeManaging.Infrastructure.EntityConfigurations
{
    internal class GenderEntityTypeConfiguration : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> orderStatusConfiguration)
        {
            orderStatusConfiguration.ToTable("genders", EmployeeContext.DEFAULT_SCHEMA);

            orderStatusConfiguration.HasKey(o => o.Id);

            orderStatusConfiguration.Property(o => o.Id)
                .HasDefaultValue(1)
                .ValueGeneratedNever()
                .IsRequired();

            orderStatusConfiguration.Property(o => o.Name)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
