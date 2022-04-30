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
    public class SocialMediaRepository : ISocialMediaRepository
    {
        private readonly DidTheyPlayTogetherDbContext context;
        public SocialMediaRepository(DidTheyPlayTogetherDbContext context)
        {
            this.context = context;
        }

        public SocialMediaID AddSocialMedia(SocialMediaID socialMediaIDs)
        {
            socialMediaIDs.InsertionDate = DateTime.Now;
            socialMediaIDs.UpdateDate = DateTime.Now;
            socialMediaIDs.Status = 1;
            context.socialMediaIDs.Add(socialMediaIDs);
            context.SaveChanges();
            return socialMediaIDs;
        }

        public SocialMediaID GetSocialMedia(int ID)
        {
            return context.socialMediaIDs.SingleOrDefault(x => x.ID == ID);
        }

        public SocialMediaID UpdateSocialMedia(SocialMediaID socialMediaIDs)
        {
            socialMediaIDs.UpdateDate = DateTime.Now;
            context.Entry(socialMediaIDs).State = EntityState.Modified;
            context.SaveChanges();
            return socialMediaIDs;
        }
    }
}
