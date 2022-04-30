using Domain.Models;

namespace Domain.Interfaces
{
    public interface ICrewRepository
    {
        Crew AddCrew(Crew crew);
        Crew GetCrew(int ID);
        Crew UpdateCrew(Crew crew);
    }
}
