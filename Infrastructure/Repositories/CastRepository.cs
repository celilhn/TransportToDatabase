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
    public class CastRepository : ICastRepository
    {
        private readonly DidTheyPlayTogetherDbContext context;
        public CastRepository(DidTheyPlayTogetherDbContext context)
        {
            this.context = context;
        }

        public Cast AddCast(Cast cast)
        {
            cast.InsertionDate = DateTime.Now;
            cast.UpdateDate = DateTime.Now;
            cast.Status = 1;
            context.Casts.Add(cast);
            context.SaveChanges();
            return cast;
        }

        public Cast GetCast(int ID)
        {
            return context.Casts.SingleOrDefault(x => x.ID == ID);
        }

        public Cast UpdateCast(Cast cast)
        {
            cast.UpdateDate = DateTime.Now;
            context.Entry(cast).State = EntityState.Modified;
            context.SaveChanges();
            return cast;
        }
    }
}
