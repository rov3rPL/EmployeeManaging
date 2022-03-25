using EmployeeManaging.Domain.SeedWork;

namespace EmployeeManaging.Domain
{
    public interface IKeyGenerator<TKey>
    {
        TKey GetNextKey();
    }
}
