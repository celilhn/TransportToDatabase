using Application.Models;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IMovieDbPeopleService
    {
        List<People> GetPopularPeople(string page = "");
        PersonDetail GetDetail(int personID);
        PoepleMovieCreditModel GetMovieCredits(int personID);
        PoepleMovieCreditModel GetTvCredits(int personID);
        PeopleExternalIDModel GetExternalIDs(int personID);
        PeopleImageModel GetImages(int personID);
    }
}
