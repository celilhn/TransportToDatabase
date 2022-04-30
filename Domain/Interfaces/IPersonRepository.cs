using Domain.Models;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IPersonRepository
    {
        KnownFor AddPersonKnownFor(KnownFor knownFor);
        Person AddPerson(Person person);
        Person GetPerson(int id);
        Person GetPerson(string name);
        List<Person> GetPeople();
        Person UpdatePerson(Person person);
    }
}
