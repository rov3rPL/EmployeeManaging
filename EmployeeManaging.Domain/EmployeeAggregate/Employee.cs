using EmployeeManaging.Domain.SeedWork;

namespace EmployeeManaging.Domain.EmployeeAggregate
{
    public class Employee : Entity<int>, IAggregate
    {
        public Surname Surname { get; private set; }
        public Gender Gender { get; private set; }
        private int _genderId; //To be used only by EmployeeEntityTypeConfiguration

        public RegistrationNumber RegistrationNo { get; private set; }

        protected Employee() { }

        public Employee(Surname name, Gender gender, RegistrationNumber regNo) : this()
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

        public virtual void Update(Surname name, Gender gender)
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
