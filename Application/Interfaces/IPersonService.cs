using Application.ViewModels;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IPersonService
    {
        KnownForDto AddPersonKnownFor(KnownForDto knownFor);
        PersonDto GetPerson(int id);
        PersonDto GetPerson(string name);
        List<PersonDto> GetPeople();
        PersonDto SavePerson(PersonDto person);
    }
}
