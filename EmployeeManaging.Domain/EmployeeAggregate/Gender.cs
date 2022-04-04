using EmployeeManaging.Domain.SeedWork;

namespace EmployeeManaging.Domain.EmployeeAggregate
{
    public class Gender : Enumeration //TODO cr nie wiem czy korzystałeś z jakiegoś gotowca, ale takie obsłużenie enuma to zdecydowany overkill
    {
        public static Gender Male = new Gender(1, nameof(Male).ToLowerInvariant());
        public static Gender Female = new Gender(2, nameof(Female).ToLowerInvariant());
        
        public Gender(int id, string name)
            : base(id, name)
        {
        }

        public static IEnumerable<Gender> List() =>
            new[] { Male, Female };

        public static Gender FromName(string name)
        {
            var gender = List()
                .SingleOrDefault(s => String.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

            if (gender == null)
            {
                throw new InvalidCastException($"Possible values for Gender: {String.Join(",", List().Select(s => s.Name))}");
            }

            return gender;
        }

        public static Gender From(int id)
        {
            var gender = List().SingleOrDefault(s => s.Id == id);

            if (gender == null)
            {
                throw new InvalidCastException($"Possible values for Gender: {String.Join(",", List().Select(s => s.Name))}");
            }

            return gender;
        }
    }

}
