using System.Collections.ObjectModel;

namespace MovieExplorer.ViewModels
{
    public class VMCompleteTvShow : VMItemTvShow
    {
        private string background;
        private string summary;
        private double rate;
        private string numSeasons;
        private string numEpisodes;
        private int day;
        private int month;
        private string web;
        private string status;
        private string trailers;

        public ObservableCollection<string> Genres { get; set; }
        public ObservableCollection<VMCast> Cast { get; set; }
        public ObservableCollection<VMCreator> Creator { get; set; }
        public ObservableCollection<VMCrew> Crew { get; set; }
        public ObservableCollection<VMSeason> Season { get; set; }

        public int Day
        {
            get
            {
                return day;
            }
            set
            {
                if (value != day)
                {
                    day = value;
                    RaisePropertyChanged("Day");
                }
            }
        }
        public int Month
        {
            get
            {
                return month;
            }
            set
            {
                if (value != month)
                {
                    month = value;
                    RaisePropertyChanged("Month");
                }
            }
        }
        public string NumSeasons
        {
            get
            {
                return string.Format("{0} Seasons", numSeasons);
            }
            set
            {
                if (value != numSeasons)
                {
                    numSeasons = value;
                    RaisePropertyChanged("NumSeasons");
                }
            }
        }
        public string NumEpisodes
        {
            get
            {               
                return string.Format("{0} Episodes", numEpisodes);                
            }
            set
            {
                if (value != numEpisodes)
                {
                    numEpisodes = value;
                    RaisePropertyChanged("NumEpisodes");
                }
            }
        }
        public string Background
        {
            get
            {
                return background;
            }
            set
            {
                if (value != background)
                {
                    background = value;
                    RaisePropertyChanged("Background");
                }
            }
        }
        public string Summary
        {
            get
            {
                return summary;
            }
            set
            {
                if (value != summary)
                {
                    summary = value;
                    RaisePropertyChanged("Summary");
                }
            }
        }
        public double Rate
        {
            get
            {
                return rate;
            }
            set
            {
                if (value != rate)
                {
                    rate = value;
                    RaisePropertyChanged("Rate");
                }
            }
        }      
        public string Web
        {
            get
            {
                return web;
            }
            set
            {
                if (value != web)
                {
                    background = value;
                    RaisePropertyChanged("Web");
                }
            }
        }
        public string Status
        {
            get
            {
                return status;
            }
            set
            {
                if (value != status)
                {
                    status = value;
                    RaisePropertyChanged("Status");
                }
            }
        }

        public void UpdateObservables()
        {
            RaisePropertyChanged("Crew");
            RaisePropertyChanged("Cast");
            RaisePropertyChanged("Genres");
            RaisePropertyChanged("Creator");
            RaisePropertyChanged("Season");
        }

        public VMCompleteTvShow()
        {
            Crew = new ObservableCollection<VMCrew>();
            Cast = new ObservableCollection<VMCast>();
            Creator = new ObservableCollection<VMCreator>();
            Season = new ObservableCollection<VMSeason>();
            Genres = new ObservableCollection<string>();
        }
    }
}
