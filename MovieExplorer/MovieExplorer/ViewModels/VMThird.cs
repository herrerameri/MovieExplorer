using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using MovieExplorer.ViewModels.Base;
using MovieExplorer.Services;

namespace MovieExplorer.ViewModels
{
    public class VMThird : VMBase
    {
        #region Properties
        private VMCompleteTvShow tvShow;
        private INavigationService navigationService;

        public VMCompleteTvShow TvShow
        {
            get { return tvShow; }
            set
            {
                if (value != tvShow)
                {
                    tvShow = value;
                    RaisePropertyChanged("TvShow");
                }
            }
        }
        #endregion

        public VMThird(INavigationService navServ)
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
        public async void LoadCompleteTvShow(VMItemTvShow chosen)
        {
            TvShow = new VMCompleteTvShow
            {
                Id = chosen.Id,
                Year = chosen.Year,
                Rate = chosen.Rate,
                Title = chosen.Title,
                Poster = chosen.Poster
            };

            ManageProgressBar(true);
            var client = new ServiceReferenceTvShowInfo.WSTvInfoPortTypeClient();
            ServiceReferenceTvShowInfo.GetTvShowDataByIdResponse result =
                                       await client.GetTvShowDataByIdAsync(TvShow.Id);

            var serie = result.@return;
            TvShow.Poster = serie.Poster;
            TvShow.Background = serie.Background;
            TvShow.Status = serie.Status;
            TvShow.Summary = serie.Summary;
            TvShow.Day = serie.Day;
            TvShow.Month = serie.Month;
            TvShow.NumEpisodes = serie.NumEpisodes.ToString();
            TvShow.NumSeasons = serie.NumSeasons.ToString();
            TvShow.Web = serie.Web;
            TvShow.Cast = new ObservableCollection<VMCast>();
            TvShow.Crew = new ObservableCollection<VMCrew>();
            TvShow.Creator = new ObservableCollection<VMCreator>();
            TvShow.Genres = new ObservableCollection<string>();

            if(serie.Cast != null)
            {
                foreach (var actorInfo in serie.Cast)
                {
                    var cast = new VMCast
                    {
                        Character = actorInfo.Character,
                        Name = actorInfo.Name,
                        Picture = actorInfo.Picture
                    };
                    TvShow.Cast.Add(cast);
                }
            }

            if (serie.Crew != null)
            { 
                foreach (var crewInfo in serie.Crew)
                {
                    var crew = new VMCrew()
                    {
                        Department = crewInfo.Department,
                        Job = crewInfo.Job,
                        Name = crewInfo.Name,
                        Picture = crewInfo.Picture
                    };
                    TvShow.Crew.Add(crew);
                }
            }
            if (serie.Creators != null)
            {
                foreach (var creatorInfo in serie.Creators)
                {
                    var creator = new VMCreator()
                    {
                        Name = creatorInfo.Name,
                        Picture = creatorInfo.Picture
                    };
                    TvShow.Creator.Add(creator);
                }
            }
            if (serie.Seasons != null)
            {
                foreach (var seasonInfo in serie.Seasons)
                {
                    var season = new VMSeason
                    {
                        AirDate = seasonInfo.AirDate,
                        Number = seasonInfo.Number.ToString(),
                        Poster = seasonInfo.Poster                        
                    };
                    TvShow.Season.Add(season);
                }
            }
            if (serie.Genres != null)
            { 
                foreach (var genre in serie.Genres)
                {
                    TvShow.Genres.Add(genre);
                }
            }
            TvShow.UpdateObservables();
            ManageProgressBar(false);
        }
        #endregion

        private void ManageProgressBar(bool visible)
        {   
            RaisePropertyChanged(visible ? "SHOW" : "HIDE");
        }
    }
}