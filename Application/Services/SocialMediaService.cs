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
    public class SocialMediaService : ISocialMediaService
    {
        private readonly ISocialMediaRepository socialMediaRepository;
        private readonly IMapper mapper;

        public SocialMediaService(ISocialMediaRepository socialMediaRepository, IMapper mapper)
        {
            this.socialMediaRepository = socialMediaRepository;
            this.mapper = mapper;
        }

        public SocialMediaIDDto GetSocialMedia(int ID)
        {
            return mapper.Map<SocialMediaIDDto>(socialMediaRepository.GetSocialMedia(ID));
        }

        public SocialMediaIDDto SaveSocialMedia(SocialMediaIDDto socialMedias)
        {
            if (socialMedias.ID > 0)
            {
                SocialMediaID personTemp = socialMediaRepository.GetSocialMedia(socialMedias.ID);
                personTemp = mapper.Map<SocialMediaID>(socialMedias);
                personTemp = socialMediaRepository.UpdateSocialMedia(personTemp);
                socialMedias = mapper.Map<SocialMediaIDDto>(personTemp);
            }
            else
            {
                socialMedias = mapper.Map<SocialMediaIDDto>(socialMediaRepository.AddSocialMedia(mapper.Map<SocialMediaID>(socialMedias)));
            }
            return socialMedias;
        }
    }
}
