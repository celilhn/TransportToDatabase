using Application.Interfaces;
using Application.ViewModels;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository PersonRepository;
        private readonly IMapper mapper;

        public PersonService(IPersonRepository PersonRepository, IMapper mapper)
        {
            this.PersonRepository = PersonRepository;
            this.mapper = mapper;
        }

        public PersonDto GetPerson(int id)
        {
            return mapper.Map<PersonDto>(PersonRepository.GetPerson(id));
        }

        public PersonDto GetPerson(string name)
        {
            return mapper.Map<PersonDto>(PersonRepository.GetPerson(name));
        }

        public List<PersonDto> GetPeople()
        {
            return mapper.Map<List<PersonDto>>(PersonRepository.GetPeople());
        }

        public PersonDto SavePerson(PersonDto person)
        {
            if(person != null)
            {
                if (person.ID > 0)
                {
                    Person personTemp = PersonRepository.GetPerson(person.ID);
                    personTemp = mapper.Map<Person>(person);
                    personTemp = PersonRepository.UpdatePerson(personTemp);
                    person = mapper.Map<PersonDto>(personTemp);
                }
                else
                {
                    person = mapper.Map<PersonDto>(PersonRepository.AddPerson(mapper.Map<Person>(person)));
                }
            }
            return person;
        }

        public KnownForDto AddPersonKnownFor(KnownForDto knownFor)
        {
            return mapper.Map<KnownForDto>(PersonRepository.AddPersonKnownFor(mapper.Map<KnownFor>(knownFor)));
        }
    }
}
