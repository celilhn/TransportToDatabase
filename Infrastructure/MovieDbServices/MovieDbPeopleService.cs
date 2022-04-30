using Application.Interfaces;
using Application.Models;
using Application.Utilities;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Infrastructure.MovieDbServices
{
    public class MovieDbPeopleService : IMovieDbPeopleService
    {
        private readonly string apiKey = "3a1945ec77e5a87c3deccf7477584891";// AppUtilities.GetConfigurationValue("MovieApiKey");
        private readonly string URL = "https://api.themoviedb.org/3";// AppUtilities.GetConfigurationValue("MovieUrl");
        //private readonly string ImageUrl = AppUtilities.GetConfigurationValue("MovieImageUrl");
        private readonly static string resource = "/person/popular";
        private readonly IHttpUtilities httpUtilities;
        public MovieDbPeopleService(IHttpUtilities httpUtilities)
        {
            this.httpUtilities = httpUtilities;
        }

        public List<People> GetPopularPeople(string page = "")
        {
            List<People> people = null;
            try
            {
                string endpoint = URL + resource + "?api_key=" + apiKey;
                if (page != "")
                {
                    endpoint = endpoint + "&page=" + page + "";
                }
                string response = httpUtilities.ExecuteHttpRequest(endpoint);
                if (response != "")
                {
                    people = JsonSerializer.Deserialize<PopularPeople>(response).Results;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return people;
        }

        public PersonDetail GetDetail(int personID)
        {
            PersonDetail person = null;
            try
            {
                string endpoint = URL + "/person/" + personID + "?api_key=" + apiKey;
                string response = httpUtilities.ExecuteHttpRequest(endpoint);
                if (response != "")
                {
                    person = JsonSerializer.Deserialize<PersonDetail>(response);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return person;
        }

        public PoepleMovieCreditModel GetMovieCredits(int personID)
        {
            PoepleMovieCreditModel personMovieCredits = null;
            try
            {
                string endpoint = URL + "/person/" + personID + "/movie_credits?api_key=" + apiKey;
                string response = httpUtilities.ExecuteHttpRequest(endpoint);
                if (response != "")
                {
                    personMovieCredits = JsonSerializer.Deserialize<PoepleMovieCreditModel>(response);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return personMovieCredits;
        }

        public PoepleMovieCreditModel GetTvCredits(int personID)
        {
            PoepleMovieCreditModel personMovieCredits = null;
            try
            {
                string endpoint = URL + "/person/" + personID + "/tv_credits?api_key=" + apiKey;
                string response = httpUtilities.ExecuteHttpRequest(endpoint);
                if (response != "")
                {
                    personMovieCredits = JsonSerializer.Deserialize<PoepleMovieCreditModel>(response);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return personMovieCredits;
        }

        public PeopleExternalIDModel GetExternalIDs(int personID)
        {
            PeopleExternalIDModel externalIDs = null;
            try
            {
                string endpoint = URL + "/person/" + personID + "/external_ids?api_key=" + apiKey;
                string response = httpUtilities.ExecuteHttpRequest(endpoint);
                if (response != "")
                {
                    //externalIDs = JsonSerializer.Deserialize<PeopleExternalIDModel>(response);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return externalIDs;
        }

        public PeopleImageModel GetImages(int personID)
        {
            PeopleImageModel images = null;
            try
            {
                string endpoint = URL + "/person/" + personID + "/images?api_key=" + apiKey;
                string response = httpUtilities.ExecuteHttpRequest(endpoint);
                if (response != "")
                {
                    images = JsonSerializer.Deserialize<PeopleImageModel>(response);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return images;
        }
    }
}
