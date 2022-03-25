namespace EmployeeManaging.Domain
{
    public interface IKeyGeneratorStrategy
    {
        IKeyGenerator<TKeyType> GetKeyGenerator<TKeyType>();
    }
}
