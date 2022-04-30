using Application.ViewModels;

namespace Application.Interfaces
{
    public interface IImageService
    {
        ImageDto SaveImage(ImageDto image);
        ImageDto GetImage(int ID);
    }
}
