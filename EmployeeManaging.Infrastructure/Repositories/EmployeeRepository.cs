using Microsoft.EntityFrameworkCore;
using EmployeeManaging.Domain.SeedWork;
using EmployeeManaging.Domain.EmployeeAggregate;

namespace EmployeeManaging.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeContext _context;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public EmployeeRepository(EmployeeContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Employee Add(Employee employee)
        {
            return _context.Employees.Add(employee).Entity;

        }

        public async Task<Employee> GetAsync(int employeeId)
        {
            var employee = await _context
                                .Employees
                                .Include(x => x.Surname)
                                .FirstOrDefaultAsync(o => o.Id == employeeId);
            if (employee == null)
            {
                employee = _context
                            .Employees
                            .Local
                            .FirstOrDefault(o => o.Id == employeeId);
            }
            if (employee != null)
            {
                //await _context.Entry(employee)
                    //.Collection(i => i.Items).LoadAsync();
                await _context.Entry(employee)
                    .Reference(i => i.Gender).LoadAsync();
            }

            return employee;
        }

        public void Update(Employee employee)
        {
            _context.Entry(employee).State = EntityState.Modified;
        }

    }
}
