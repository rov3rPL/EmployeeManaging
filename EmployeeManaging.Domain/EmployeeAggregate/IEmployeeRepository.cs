using EmployeeManaging.Domain.SeedWork;

namespace EmployeeManaging.Domain.EmployeeAggregate
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Employee Add(Employee employee);

        void Update(Employee employee);

        Task<Employee> GetAsync(EmployeeId employeeId);
    }
}
