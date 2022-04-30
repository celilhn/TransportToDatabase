using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly DidTheyPlayTogetherDbContext context;
        public PersonRepository(DidTheyPlayTogetherDbContext context)
        {
            this.context = context;
        }

        public KnownFor AddPersonKnownFor(KnownFor knownFor)
        {
            knownFor.InsertionDate = DateTime.Now;
            knownFor.UpdateDate = DateTime.Now;
            knownFor.Status = 1;
            context.KnownFors.Add(knownFor);
            context.SaveChanges();
            return knownFor;
        }

        public Person AddPerson(Person person)
        {
            if (person.Birthday == null || person.Birthday == DateTime.MinValue )
            {
                person.Birthday = new DateTime(2050, 12, 30);
            }
            if (person.Deathday == null || person.Deathday == DateTime.MinValue)
            {
                person.Deathday = new DateTime(2050, 12, 30);
            }
            person.InsertionDate = DateTime.Now;
            person.UpdateDate = DateTime.Now;
            person.Status = 1;
            context.People.Add(person);
            context.SaveChanges();
            return person;
        }

        public Person GetPerson(int id)
        {
            return context.People.SingleOrDefault(x => x.ID == id);
        }

        public Person GetPerson(string name)
        {
            return context.People.SingleOrDefault(x => x.Name == name);
        }

        public List<Person> GetPeople()
        {
            return context.People.ToList();
        }

        public Person UpdatePerson(Person person)
        {
            person.UpdateDate = DateTime.Now;
            context.Entry(person).State = EntityState.Modified;
            context.SaveChanges();
            return person;
        }
    }
}
