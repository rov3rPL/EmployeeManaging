using Microsoft.EntityFrameworkCore;
using EmployeeManaging.Domain.SeedWork;
using EmployeeManaging.Domain.EmployeeAggregate;
using EmployeeManaging.Infrastructure.EntityConfigurations;

namespace EmployeeManaging.Infrastructure
{
    public class EmployeeContext : DbContext, IUnitOfWork
    {
        public const string DEFAULT_SCHEMA = "employees";
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Gender> Genders { get; set; }


        public EmployeeContext(DbContextOptions<EmployeeContext> options)
            : base(options)
        {
        
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new GenderEntityTypeConfiguration());
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}