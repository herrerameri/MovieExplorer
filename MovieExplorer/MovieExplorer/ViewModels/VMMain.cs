using System;
using System.Windows.Input;
using MovieExplorer.ViewModels.Base;
using MovieExplorer.Services;
using System.Collections.ObjectModel;

namespace MovieExplorer.ViewModels
{
    public class VMMain : VMBase
    {
        #region Properties

        private INavigationService navigationService;
        public ObservableCollection<VMItemFilm> MovieCollection { get; set; }
        public ObservableCollection<VMItemTvShow> TvShowCollection { get; set; }

        private bool visibleMoviePivot;
        private string favourite1;
        private string favourite2;
        private string favourite3;
        private string favourite4;
        private string favourite5;
        private bool progressBarEnabled;
        private string movie;
        private string tvShow;

        public bool ProgressBarEnabled
        {
            get
            {
                return progressBarEnabled;
            }
            set
            {
                progressBarEnabled = value;
                RaisePropertyChanged("ProgressBarEnabled");
            }
        }
       
        public string Movie
        {
            get
            {
                return movie;
            }

            set
            {
                movie = value;
                RaisePropertyChanged("Movie");
                RaisePropertyChanged("NumResultsMovies");
                setSearchCommand.Value.RaiseCanExecuteChanged(this);
            }
        }
        public string TvShow
        {
            get
            {
                return tvShow;
            }

            set
            {
                tvShow = value;
                RaisePropertyChanged("TvShow");
                RaisePropertyChanged("NumResultsTvShows");
                setSearchCommand.Value.RaiseCanExecuteChanged(this);
            }
        }
        public string Favourite1
        {
            get
            {
                return favourite1;
            }

            set
            {
                favourite1 = value;
                RaisePropertyChanged("Favourite1");
            }
        }
        public string Favourite2
        {
            get
            {
                return favourite2;
            }

            set
            {
                favourite2 = value;
                RaisePropertyChanged("Favourite2");
            }
        }
        public string Favourite3
        {
            get
            {
                return favourite3;
            }

            set
            {
                favourite3 = value;
                RaisePropertyChanged("Favourite3");
            }
        }
        public string Favourite4
        {
            get
            {
                return favourite4;
            }

            set
            {
                favourite4 = value;
                RaisePropertyChanged("Favourite4");
            }
        }
        public string Favourite5
        {
            get
            {
                return favourite5;
            }

            set
            {
                favourite5 = value;
                RaisePropertyChanged("Favourite5");
            }
        }
        public string NumResultsMovies
        {
            get
            {
                if (!string.IsNullOrEmpty(movie) && !progressBarEnabled)
                {
                    return string.Format("{1} Movies that match with '{0}'", movie, MovieCollection.Count);
                }

                return " ";
            }
        }
        public string NumResultsTvShows
        {
            get
            {
                if (!string.IsNullOrEmpty(tvShow) && !progressBarEnabled)
                {
                    return string.Format("{1} TV Shows that match with '{0}'", tvShow, TvShowCollection.Count);
                }

                return " ";
            }
        }
        #endregion

        public VMMain(INavigationService navServ)
        {
            InitializeCommands();
            navigationService = navServ;
            MovieCollection = new ObservableCollection<VMItemFilm>();
            TvShowCollection = new ObservableCollection<VMItemTvShow>();
            ProgressBarEnabled = false;
            visibleMoviePivot = true;
            InitializeFavourites();
        }

        public void SetVisiblePivot(int id)
        {
            visibleMoviePivot = (id == 0);
            InitializeFavourites();
        }

        #region WebServices
        async void LoadMovies(string movieTitle)
        {
            ProgressBarEnabled = true;
            var client = new ServiceReferenceFilmSearch.WSFilmSearchPortTypeClient();
            ServiceReferenceFilmSearch.SearchMoviesByNameResponse result =
                                       await client.SearchMoviesByNameAsync(movieTitle);

            foreach (var movieResult in result.@return)
            {
                this.MovieCollection.Add(new VMItemFilm()
                {
                    Id = movieResult.Id,
                    Title = movieResult.Title,
                    Description = movieResult.Description,
                    Year = movieResult.Year,
                    Poster = movieResult.Poster
                });
            }
            Movie = movieTitle;
            ProgressBarEnabled = false;
        }

        async void LoadTvShow(string tvShowTitle)
        {
            ProgressBarEnabled = true;
            var client = new ServiceReferenceTvShowSearch.WSTvSearchPortTypeClient();
            ServiceReferenceTvShowSearch.SearchTvByNameResponse result =
                                       await client.SearchTvByNameAsync(tvShowTitle);

            foreach (var tvShowResult in result.@return)
            {
                this.TvShowCollection.Add(new VMItemTvShow()
                {
                    Id = tvShowResult.Id,
                    Title = tvShowResult.Title,
                    Rate = Convert.ToDouble(tvShowResult.Rate),
                    Year = tvShowResult.Year,
                    Poster = tvShowResult.Poster
                });
            }
            TvShow = tvShowTitle;
            ProgressBarEnabled = false;
        }
        #endregion

        #region Commands

        private Lazy<DelegateCommand<string>> setSearchCommand;
        private Lazy<DelegateCommand<string>> clearListCommand;

        public ICommand SetSearchCommand
        {
            get
            {
                return setSearchCommand.Value;
            }
        }
        public ICommand ClearListCommand
        {
            get
            {
                return clearListCommand.Value;
            }
        }

        private void InitializeCommands()
        {
            setSearchCommand = new Lazy<DelegateCommand<string>>(
                () => new DelegateCommand<string>(SetSearchCommandExecute,
                                                  SetSearchCommandCanExecute));
            clearListCommand = new Lazy<DelegateCommand<string>>(
                () => new DelegateCommand<string>(ClearListCommandExecute, 
                                                  SetClearCommandCanExecute));

        }        
        private void InitializeFavourites()
        {
            if (visibleMoviePivot)
            {
                Favourite1 = "Harry Potter";
                Favourite2 = "Avengers";
                Favourite3 = "Iron man";
                Favourite4 = "Sherlock Holmes";
                Favourite5 = "Titanic";
            }
            else {
                Favourite1 = "Homeland";
                Favourite2 = "Lost";
                Favourite3 = "Prison Break";
                Favourite4 = "Gotham";
                Favourite5 = "Flash";
            }
        }

        public void SetSearchCommandExecute(string param)
        {
            if (visibleMoviePivot)
            {
                RaisePropertyChanged("NumResultsMovies");
                MovieCollection.Clear();
                LoadMovies(param);
            }
            else
            {
                RaisePropertyChanged("NumResultsTvShows");
                TvShowCollection.Clear();
                LoadTvShow(param);
            }
        }

        public bool SetSearchCommandCanExecute(string param)
        {             
            return !progressBarEnabled && !string.IsNullOrEmpty(param); 
        }

        public bool SetClearCommandCanExecute(string param)
        {
            return !progressBarEnabled;
        }
        
        public void ClearListCommandExecute(string param)
        {
            if (visibleMoviePivot) {
                MovieCollection.Clear();
                RaisePropertyChanged("NumResultsMovies");
            }
            else { 
                TvShowCollection.Clear();
                RaisePropertyChanged("NumResultsTvShows");
            }
        }
        #endregion

        #region Callbacks

        internal void OnSelectedItemFilm(VMItemFilm selectedItem)
        {
            if (selectedItem != null)
            {
                navigationService.NavigateToSecondPage(selectedItem);
            }
        }

        internal void OnSelectedItemTvShow(VMItemTvShow selectedItem)
        {
            if(selectedItem != null)
            { 
                navigationService.NavigateToThirdPage(selectedItem);
            }
        }
        #endregion
    }
}
