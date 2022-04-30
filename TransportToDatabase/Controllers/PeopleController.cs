using Application.Interfaces;
using Application.Models;
using Application.ViewModels;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using static Domain.Constants.Constants;

namespace TransportToDatabase.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPersonService personService;
        //private readonly IFilmService filmService;
        //private readonly IPlayedFilmService playedFilmService;
        //private readonly IPlayedSerieService playedSerieService;
        private readonly IMovieDbPeopleService peopleService;
        //public PeopleController(IPersonService personService/*, IFilmService filmService, IPlayedFilmService playedFilmService, IPlayedSerieService playedSerieService*/, IMovieDbPeopleService peopleService)
        //{
        //    this.personService = personService;
        //    //this.filmService = filmService;
        //    //this.playedFilmService = playedFilmService;
        //    //this.playedSerieService = playedSerieService;
        //    this.peopleService = peopleService;
        //}

        public PeopleController(IPersonService personService, IMovieDbPeopleService peopleService)
        {
            this.personService = personService;
            this.peopleService = peopleService;
        }

        [HttpGet]
        public IActionResult GetPopular()
        {
            List<People> people = null;
            try
            {
                people = peopleService.GetPopularPeople();
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(people);
        }

        //[HttpGet]
        //public IActionResult AddPopularPeopleFromMovieDb()
        //{
        //    List<People> people = null;
        //    FamousDto famous = null;
        //    PlayedFilmDto playedFilm = null;
        //    PlayedSerieDto playedSerie = null;
        //    FilmDto film = null;
        //    int counterofFamousAdded = 0;
        //    int counterofFilmAdded = 0;
        //    int counterofPlayedFilmAdded = 0;
        //    int counterofPlayedSerieAdded = 0;
        //    try
        //    {
        //        for (int i = 1; i < 500; i++)
        //        {
        //            people = peopleService.GetPopularPeople(i.ToString());
        //            foreach (People human in people)
        //            {
        //                famous = famousService.GetFamous(human.Name);
        //                if (famous == null)
        //                {
        //                    famous = SaveFamaous(human);
        //                    counterofFamousAdded++;
        //                    foreach (KnownFor knowFor in human.KnownFor)
        //                    {
        //                        film = filmService.GetFilmByOriginalName(knowFor.OriginalTitle);
        //                        counterofFilmAdded++;
        //                        if (film == null)
        //                        {
        //                            film = SaveFilm(knowFor);
        //                        }
        //                        if (knowFor.MediaType == MediaTypes.movie.ToString())
        //                        {
        //                            playedFilm = playedFilmService.GetPlayedFilm(famous.ID, film.ID);
        //                            if(playedFilm == null)
        //                            {
        //                                playedFilm = SavePlayedFilm(famous, film);
        //                                counterofPlayedFilmAdded++;
        //                            }
        //                        }
        //                        else if(knowFor.MediaType == MediaTypes.tv.ToString())
        //                        {
        //                            playedSerie = playedSerieService.GetPlayedSerie(famous.ID, film.ID);
        //                            if(playedSerie == null)
        //                            {
        //                                playedSerie = SavePlayedSerie(famous, film);
        //                                counterofPlayedSerieAdded++;
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //    return Ok(counterofFamousAdded + " Adet Ünlü, " + counterofFilmAdded + " Adet Film, " + counterofPlayedFilmAdded + " Adet PLayedFilm, " + counterofPlayedSerieAdded + " Adet PlayedSerie Eklendi.");
        //}

        //private FamousDto SaveFamaous(People human)
        //{
        //    FamousDto famous = null;
        //    try
        //    {
        //        famous = new FamousDto();
        //        famous.Gender = (short)human.Gender;
        //        famous.Name = human.Name;
        //        famous.Popularity = human.Popularity;
        //        famous.ProfilePath = human.ProfilePath;
        //        famous.SourceID = (int)SourceTypes.MovieDb;
        //        famous = famousService.SaveFamous(famous);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //    return famous;
        //}

        //private FilmDto SaveFilm(KnownFor knowFor)
        //{
        //    FilmDto film = null;
        //    try
        //    {
        //        film = new FilmDto();
        //        film.Name = knowFor.Name;
        //        film.OriginalName = knowFor.OriginalName;
        //        film.PosterPath = knowFor.PosterPath;
        //        if (knowFor.ReleaseDate != null)
        //        {
        //            if (knowFor.ReleaseDate.Count() > 3)
        //            {
        //                film.ReleaseDate = Convert.ToInt32(knowFor.ReleaseDate.Substring(0, 4));
        //            }
        //        }
        //        film.Country = "Other";
        //        film.Subject = knowFor.Overview;
        //        film.SourceID = (int)SourceTypes.MovieDb;
        //        film = filmService.SaveFilm(film);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //    return film;
        //}

        //private PlayedFilmDto SavePlayedFilm(FamousDto famous, FilmDto film)
        //{
        //    PlayedFilmDto playedFilm = null;
        //    try
        //    {
        //        playedFilm = new PlayedFilmDto();
        //        playedFilm.FamousID = famous.ID;
        //        playedFilm.FilmID = film.ID;
        //        playedFilm = playedFilmService.SavePlayedFilm(playedFilm);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //    return playedFilm;
        //}

        //private PlayedSerieDto SavePlayedSerie(FamousDto famous, FilmDto film)
        //{
        //    PlayedSerieDto playedSerie = null;
        //    try
        //    {
        //        playedSerie = new PlayedSerieDto();
        //        playedSerie.FamousID = famous.ID;
        //        playedSerie.FilmID = film.ID;
        //        playedSerie = playedSerieService.SavePlayedSerie(playedSerie);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //    return playedSerie;
        //}
    }
}
