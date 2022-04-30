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
    public class ImageRepository : IImageRepository
    {
        private readonly DidTheyPlayTogetherDbContext context;
        public ImageRepository(DidTheyPlayTogetherDbContext context)
        {
            this.context = context;
        }

        public Image AddImage(Image image)
        {
            image.InsertionDate = DateTime.Now;
            image.UpdateDate = DateTime.Now;
            image.Status = 1;
            context.Images.Add(image);
            context.SaveChanges();
            return image;
        }

        public Image GetImage(int ID)
        {
            return context.Images.SingleOrDefault(x => x.ID == ID);
        }

        public Image UpdateImage(Image image)
        {
            image.UpdateDate = DateTime.Now;
            context.Entry(image).State = EntityState.Modified;
            context.SaveChanges();
            return image;
        }
    }
}
