using Application.ViewModels;

namespace Application.Interfaces
{
    public interface ICrewService
    {
        CrewDto SaveCrew(CrewDto crew);
        CrewDto GetCrew(int ID);
    }
}
