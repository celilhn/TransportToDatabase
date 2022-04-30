using Domain.Models;

namespace Domain.Interfaces
{
    public interface IImageRepository
    {
        Image AddImage(Image image);
        Image GetImage(int ID);
        Image UpdateImage(Image image);
    }
}
