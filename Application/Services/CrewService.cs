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
    public class CrewService : ICrewService
    {
        private readonly ICrewRepository crewRepository;
        private readonly IMapper mapper;

        public CrewService(ICrewRepository crewRepository, IMapper mapper)
        {
            this.crewRepository = crewRepository;
            this.mapper = mapper;
        }

        public CrewDto GetCrew(int ID)
        {
            return mapper.Map<CrewDto>(crewRepository.GetCrew(ID));
        }

        public CrewDto SaveCrew(CrewDto crew)
        {
            if (crew.ID > 0)
            {
                Crew crewTemp = crewRepository.GetCrew(crew.ID);
                crewTemp = mapper.Map<Crew>(crew);
                crewTemp = crewRepository.UpdateCrew(crewTemp);
                crew = mapper.Map<CrewDto>(crewTemp);
            }
            else
            {
                crew = mapper.Map<CrewDto>(crewRepository.AddCrew(mapper.Map<Crew>(crew)));
            }
            return crew;
        }
    }
}
