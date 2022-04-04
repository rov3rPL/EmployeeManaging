using EmployeeManaging.Domain.EmployeeAggregate;

namespace EmployeeManaging.Domain
{
    //Hi/Lo Algorithm
    public class RegistrationNumberProvider : IRegistrationNumberProvider
    {

        //todo cr Zdecydowanie nie rozumiem o co tu chodzi :)
        // Też specjalnie głupi nie jestem, także wg mnie albo to jest trochę przekombinowane albo brakuje porządnego komentarza.
        // No i mam poważne podejrzenia, że w środowisku redundantnym to podejście będzie generowało duplikaty.
        
        //https://en.wikipedia.org/wiki/Hi/Lo_algorithm
        //licznik bieżącej zarezerwowanej puli kluczy jest w zewnętrznym storage'u
        //może to być sekwencja liczb naturalnych sql lub inny storage, chodzi tylko o przechowanie bieżącego stanu licznika
        //pobranie licznika podbija go, a algorytm rezerwuje przedział, aż do wyczerpania zarezerwowanych kluczy
        //algorytm jest działa poprawnie z redundancją aplikacji (load balancery itp.),
        //ze względu, że instancje aplikacji działają na osobnych wykluczających się pulach (przedziałach) kluczy

        private static readonly object _lock = new object(); //for handling multiple calls at the same time
        private int _currentHi;
        private readonly int _maxLo = 20; //arbitrary set the size of pool
        private int _currentLo = int.MaxValue;  //starts with the maximum value to ensure the repository's first call

        private readonly IRegistrationNumberCounterRepository repository;

        public RegistrationNumberProvider(IRegistrationNumberCounterRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));

        }
        public RegistrationNumber GetNextRegistrationNumber()
        {
            return new RegistrationNumber(GetKey());
        }

        //[DONE] domyślnie stosuję konwencję, że metody i pola prywatne rozpoczynam małą literą
        private int GetKey() //todo cr metody powinny nazywać się z wielkiej litery
        {
            lock (_lock)
            {
                if (_currentLo >= _maxLo)
                {
                    _currentHi = repository.GetNextHi();
                    _currentLo = 0;
                }
                int result = _currentHi * _maxLo + _currentLo;
                _currentLo++;
                return result;
            }
        }
    }
}
