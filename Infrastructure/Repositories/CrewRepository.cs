using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class CrewRepository : ICrewRepository
    {
        private readonly DidTheyPlayTogetherDbContext context;
        public CrewRepository(DidTheyPlayTogetherDbContext context)
        {
            this.context = context;
        }

        public Crew AddCrew(Crew crew)
        {
            crew.InsertionDate = DateTime.Now;
            crew.UpdateDate = DateTime.Now;
            crew.Status = 1;
            context.Crews.Add(crew);
            context.SaveChanges();
            return crew;
        }

        public Crew GetCrew(int ID)
        {
            return context.Crews.SingleOrDefault(x => x.ID == ID);
        }

        public Crew UpdateCrew(Crew crew)
        {
            crew.UpdateDate = DateTime.Now;
            context.Entry(crew).State = EntityState.Modified;
            context.SaveChanges();
            return crew;
        }
    }
}
