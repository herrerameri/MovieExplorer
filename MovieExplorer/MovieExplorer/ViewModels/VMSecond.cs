using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using MovieExplorer.ViewModels.Base;
using MovieExplorer.Services;

namespace MovieExplorer.ViewModels
{
    public class VMSecond : VMBase
    {
        #region Properties
        private VMCompleteFilm film;
        private INavigationService navigationService;

        public VMCompleteFilm Film
        {
            get { return film; }
            set
            {
                if (value != film)
                {
                    film = value;
                    RaisePropertyChanged("Film");
                }
            }
        }
        #endregion

        public VMSecond(INavigationService navServ)
        {
            InitializeCommands();
            navigationService = navServ;
        }

        #region Commands       
        private void InitializeCommands()
        {
        }


        #endregion

        #region Web services
        public async void LoadCompleteFilm(VMItemFilm chosen)
        {
            Film = new VMCompleteFilm
            {
                Id = chosen.Id,
                Year = chosen.Year,
                Description = chosen.Description,
                Title = chosen.Title,
                Poster = chosen.Poster
            };

            ManageProgressBar(true);
            var client = new ServiceReferenceFilmInfo.WSFilmInfoPortTypeClient();
            ServiceReferenceFilmInfo.GetMovieDataByIdResponse result =
                                       await client.GetMovieDataByIdAsync(Film.Id);

            var movie = result.@return;
            Film.Rate = Convert.ToDouble(movie.Rate);
            Film.Poster = movie.Poster;
            Film.Background = movie.Background;
            Film.Director = movie.Director;
            Film.Status = movie.Status;
            Film.Summary = movie.Summary;
            Film.Web = movie.Web;
            Film.Cast = new ObservableCollection<VMCast>();
            Film.Crew = new ObservableCollection<VMCrew>();
            Film.Genres = new ObservableCollection<string>();

            if (movie.Cast != null)
            {
                foreach (var actorInfo in movie.Cast)
                {
                    var cast = new VMCast
                    {
                        Character = actorInfo.Character,
                        Name = actorInfo.Name,
                        Picture = actorInfo.Picture
                    };
                    Film.Cast.Add(cast);
                }
            }

            if (movie.Crew != null)
            {
                foreach (var crewInfo in movie.Crew)
                {
                    var crew = new VMCrew()
                    {
                        Department = crewInfo.Department,
                        Job = crewInfo.Job,
                        Name = crewInfo.Name,
                        Picture = crewInfo.Picture
                    };
                    Film.Crew.Add(crew);
                }
            }

            if (movie.Genres != null)
            {
                foreach (var genre in movie.Genres)
                {
                    Film.Genres.Add(genre);
                }
            }
            Film.UpdateObservables();
            ManageProgressBar(false);
        }
        #endregion

        private void ManageProgressBar(bool visible)
        {   
            RaisePropertyChanged(visible ? "SHOW" : "HIDE");
        }
    }
}