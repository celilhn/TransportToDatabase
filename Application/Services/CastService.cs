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
    public class CastService : ICastService
    {
        private readonly ICastRepository castRepository;
        private readonly IMapper mapper;

        public CastService(ICastRepository castRepository, IMapper mapper)
        {
            this.castRepository = castRepository;
            this.mapper = mapper;
        }

        public CastDto GetCast(int ID)
        {
            return mapper.Map<CastDto>(castRepository.GetCast(ID));
        }

        public CastDto SaveCast(CastDto cast)
        {
            if (cast.ID > 0)
            {
                Cast personTemp = castRepository.GetCast(cast.ID);
                personTemp = mapper.Map<Cast>(cast);
                personTemp = castRepository.UpdateCast(personTemp);
                cast = mapper.Map<CastDto>(personTemp);
            }
            else
            {
                cast = mapper.Map<CastDto>(castRepository.AddCast(mapper.Map<Cast>(cast)));
            }
            return cast;
        }
    }
}
