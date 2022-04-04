using EmployeeManaging.Domain.SeedWork;

namespace EmployeeManaging.Domain.EmployeeAggregate
{
    public class Employee : Entity<EmployeeId>, IAggregate
    {
        public Surname Surname { get; private set; }
        public Gender Gender { get; private set; }
        private int _genderId; //To be used only by EmployeeEntityTypeConfiguration //TODO cr nie rozumiem. Nie używane. Może jednak niepotrzebne? Niekonsekwencja w nazewnictwie globalnych pól w projekcie: z "_" lub bez

        public RegistrationNumber RegistrationNo { get; private set; }

        protected Employee() { }

        public Employee(Surname name, Gender gender, RegistrationNumber regNo) : this() //TODO cr this() niepotrzebne
        {
            if(null == name)
                throw new ArgumentNullException(nameof(name));
            if (null == gender)
                throw new ArgumentNullException(nameof(gender));
            if (null == regNo)
                throw new ArgumentNullException(nameof(regNo));


            this.Surname = name;
            this.Gender = gender;
            this.RegistrationNo = regNo;
        }

        public /*virtual*/ void Update(Surname name, Gender gender) //TODO cr skąd nagle virtual? W zadaniu piszę "Nie projektuj modelu z myślą o mechanizmach dostępu do danych (Entity Framework itp.). Stwórz jak najładniejszy model obiektowy patrząc tylko z punktu widzenia kodu.". Virtual bez uzasadnienia jest zaburzeniem poprawnego projektowania obiektów.
        {
            if (null == name)
                throw new ArgumentNullException(nameof(name));
            if (null == gender)
                throw new ArgumentNullException(nameof(gender));

            this.Surname = name;
            this.Gender = gender;
        }
    }
}
