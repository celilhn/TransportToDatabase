using Application.Interfaces;
using Application.Logging;
using Application.Models;
using Application.ViewModels;
using AutoMapper;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using static Domain.Constants.Constants;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MDbPeopleController : ControllerBase
    {
        private readonly IPersonService personService;
        private readonly ICrewService crewService;
        private readonly ICastService castService;
        private readonly ISocialMediaService socialMediaService;
        private readonly IImageService imageService;
        private readonly IMovieDbPeopleService peopleService;
        private readonly IMapper mapper;
        private readonly ILoggerManager logger;
        public MDbPeopleController(IMapper mapper, ILoggerManager logger, IPersonService personService, IMovieDbPeopleService peopleService
            , ICrewService crewService, ICastService castService, ISocialMediaService socialMediaService, IImageService imageService)
        {
            this.personService = personService;
            this.crewService = crewService;
            this.castService = castService;
            this.socialMediaService = socialMediaService;
            this.peopleService = peopleService;
            this.imageService = imageService;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetPopular(string page = "")
        {
            List<People> people = null;
            try
            {
                people = peopleService.GetPopularPeople(page);
            }
            catch (Exception ex)
            {
                logger.LogException(ex);
            }
            return Ok(people);
        }

        [HttpGet]
        public IActionResult GetDetail(int personID)
        {
            Person person = null;
            try
            {
                person = mapper.Map<Person>(peopleService.GetDetail(personID));
            }
            catch (Exception ex)
            {
                logger.LogException(ex);
            }
            return Ok(person);
        }

        [HttpGet]
        public IActionResult TransportToDatabase()
        {
            int counterOfAddedPeople = 0;
            try
            {
                counterOfAddedPeople = this.SavePeople();
            }
            catch (Exception ex)
            {
                logger.LogException(ex);
            }
            return Ok(counterOfAddedPeople + "Adet kisi Eklendi.");
        }

        private int SavePeople()
        {
            List<People> people = null;
            PersonDto person = null;
            int counter = 0;
            try
            {
                for (int i = 1; i < 500; i++)
                {
                    people = peopleService.GetPopularPeople(i.ToString());
                    if (people != null)
                    {
                        foreach (People item in people)
                        {
                            person = personService.GetPerson(item.Name);
                            if(person != null)
                            {
                                if (person.ID == 2400)
                                {
                                    string sd = "stop";
                                    this.AddImages(item, person.ID);
                                }
                            }
                            if (person == null)
                            {
                                person = this.AddPerson(person, item);
                                this.AddPersonKnownFors(item, person.ID);
                                this.AddMovieCredits(item, person.ID);
                                this.AddTvCredits(item, person.ID);
                                this.AddSocialMedias(item, person.ID);
                                this.AddImages(item, person.ID);
                                counter++;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogException(ex);
            }
            return counter;
        }

        private PersonDto AddPerson(PersonDto person, People item)
        {
            try
            {
                person = mapper.Map<PersonDto>(item);
                person = mapper.Map<PersonDto>(peopleService.GetDetail(item.PersonOldID));
                person = personService.SavePerson(person);
            }
            catch (Exception ex)
            {
                logger.LogException(ex);
            }
            return person;
        }

        private void AddPersonKnownFors(People item, int personID)
        {
            KnownForDto knownFor = null;
            try
            {
                foreach (Application.Models.KnownFor known in item.KnownFor)
                {
                    knownFor = mapper.Map<KnownForDto>(known);
                    knownFor.PersonID = personID;
                    knownFor = personService.AddPersonKnownFor(knownFor);
                }
            }
            catch (Exception ex)
            {
                logger.LogException(ex);
            }
        }

        private void AddMovieCredits(People item, int personID)
        {
            PoepleMovieCreditModel movieCredits = null;
            List<CastDto> casts = null;
            List<CrewDto> crews = null;
            try
            {
                movieCredits = peopleService.GetMovieCredits(item.PersonOldID);
                if(movieCredits != null)
                {
                    casts = mapper.Map<List<CastDto>>(movieCredits.cast);
                    this.AddCasts(casts, personID);
                    crews = mapper.Map<List<CrewDto>>(movieCredits.crew);
                    this.AddCrews(crews, personID);
                }
            }
            catch (Exception ex)
            {
                logger.LogException(ex);
            }
        }

        private void AddTvCredits(People item, int personID)
        {
            PoepleMovieCreditModel movieCredits = null;
            List<CastDto> casts = null;
            List<CrewDto> crews = null;
            try
            {
                movieCredits = peopleService.GetTvCredits(item.PersonOldID);
                if(movieCredits != null)
                {
                    casts = mapper.Map<List<CastDto>>(movieCredits.cast);
                    this.AddCasts(casts, personID);
                    crews = mapper.Map<List<CrewDto>>(movieCredits.crew);
                    this.AddCrews(crews, personID);
                }
            }
            catch (Exception ex)
            {
                logger.LogException(ex);
            }
        }
        
        private void AddCasts(List<CastDto> casts, int personID)
        {
            try
            {
                foreach (CastDto cast in casts)
                {
                    if (cast != null)
                    {
                        cast.PersonID = personID;
                        cast.Type = 1;
                        castService.SaveCast(cast);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogException(ex);
            }
        }

        private void AddCrews(List<CrewDto> crews, int personID)
        {
            try
            {
                foreach (CrewDto crew in crews)
                {
                    if (crew != null)
                    {
                        crew.PersonID = personID;
                        crew.Type = 1;
                        crewService.SaveCrew(crew);
                    }

                }
            }
            catch (Exception ex)
            {
                logger.LogException(ex);
            }
        }

        private void AddSocialMedias(People item, int personID)
        {
            SocialMediaIDDto socialMedias = null;
            try
            {
                socialMedias = mapper.Map<SocialMediaIDDto>(peopleService.GetExternalIDs(item.PersonOldID));
                if (socialMedias != null)
                {
                    socialMedias.PersonID = personID;
                    socialMedias = socialMediaService.SaveSocialMedia(socialMedias);
                }
            }
            catch (Exception ex)
            {
                logger.LogException(ex);
            }
        }

        private void AddImages(People item, int personID)
        {
            //2400
            List<ImageDto> images = null;
            try
            {
                images = mapper.Map<List<ImageDto>>(peopleService.GetImages(item.PersonOldID).PeopleImage);
                if(images != null)
                {
                    foreach (ImageDto image in images)
                    {
                        if (image != null)
                        {
                            image.OwnerID = personID;
                            image.Type = 1;
                            imageService.SaveImage(image);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogException(ex);
            }
        }
    }
}
