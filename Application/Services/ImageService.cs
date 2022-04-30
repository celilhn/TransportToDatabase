using Application.Interfaces;
using Application.ViewModels;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository imageRepository;
        private readonly IMapper mapper;

        public ImageService(IImageRepository imageRepository, IMapper mapper)
        {
            this.imageRepository = imageRepository;
            this.mapper = mapper;
        }

        public ImageDto GetImage(int ID)
        {
            return mapper.Map<ImageDto>(imageRepository.GetImage(ID));
        }

        public ImageDto SaveImage(ImageDto image)
        {
            if (image.ID > 0)
            {
                Image imageTemp = imageRepository.GetImage(image.ID);
                imageTemp = mapper.Map<Image>(image);
                imageTemp = imageRepository.UpdateImage(imageTemp);
                image = mapper.Map<ImageDto>(imageTemp);
            }
            else
            {
                image = mapper.Map<ImageDto>(imageRepository.AddImage(mapper.Map<Image>(image)));
            }
            return image;
        }
    }
}
