using Application.Models;
using Application.ViewModels;
using AutoMapper;
using Domain.Models;

namespace Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Person, PersonDto>();
            CreateMap<PersonDto, Person>();
            CreateMap<PersonDto, People>();
            CreateMap<People, PersonDto>();
            CreateMap<KnownForDto, Application.Models.KnownFor>();
            CreateMap<Application.Models.KnownFor, KnownForDto>();
            CreateMap<Domain.Models.KnownFor, KnownForDto>();
            CreateMap<KnownForDto, Domain.Models.KnownFor>();
            CreateMap<Person, PersonDetail>();
            CreateMap<PersonDetail, Person>();
            CreateMap<PersonDto, PersonDetail>();
            CreateMap<PersonDetail, PersonDto>();
            CreateMap<Cast, CastDto>();
            CreateMap<CastDto, Cast>();
            CreateMap<CastDto, MovieCast>();
            CreateMap<MovieCast, CastDto>();
            CreateMap<Crew, CrewDto>();
            CreateMap<CrewDto, Crew>();
            CreateMap<MovieCrew, CrewDto>();
            CreateMap<CrewDto, MovieCrew>();
            CreateMap<SocialMediaID, SocialMediaIDDto>();
            CreateMap<SocialMediaIDDto, SocialMediaID>();
            CreateMap<PeopleExternalIDModel, SocialMediaIDDto>();
            CreateMap<SocialMediaIDDto, PeopleExternalIDModel>();
            CreateMap<Image, ImageDto>();
            CreateMap<ImageDto, Image>();
            CreateMap<PeopleImage, ImageDto>();
            CreateMap<ImageDto, PeopleImage>();
        }
    }
}
