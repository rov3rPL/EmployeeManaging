using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EmployeeManaging.Domain.EmployeeAggregate;

namespace EmployeeManaging.Infrastructure.EntityConfigurations
{
    internal class EmployeeEntityTypeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> employeeConfiguration)
        {
            employeeConfiguration.ToTable("employees", EmployeeContext.DEFAULT_SCHEMA);

            employeeConfiguration.HasKey(o => o.Id);

            employeeConfiguration.Property(o => o.Id)
                .UseHiLo("employeeseq", EmployeeContext.DEFAULT_SCHEMA);

            //Address value object persisted as owned entity type supported since EF Core 2.0
            //employeeConfiguration
            //    .OwnsOne(o => o.Address, a =>
            //    {
            //    // Explicit configuration of the shadow key property in the owned type 
            //    // as a workaround for a documented issue in EF Core 5: https://github.com/dotnet/efcore/issues/20740
            //    a.Property<int>("EmployeeId")
            //        .UseHiLo("employeeseq", EmployeeContext.DEFAULT_SCHEMA);
            //        a.WithOwner();
            //    });

            employeeConfiguration
                .Property<int>("_genderId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("GenderId")
                .IsRequired();

            employeeConfiguration.HasOne(e => e.Gender)
                .WithMany()
                .HasForeignKey("_genderId");

            employeeConfiguration.Property<string>("RegistrationNo").IsRequired(true);

        }
    }
}
