using MovieExplorer.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieExplorer.ViewModels
{
    public class VMCompleteFilm : VMItemFilm
    {        
        private string director;
        private string background;
        private string summary;
        private double rate;
        private string web;
        private string status;
        private string trailers;
        public ObservableCollection<string> Genres { get; set; }
        public ObservableCollection<VMCast> Cast { get; set; }
        public ObservableCollection<VMCrew> Crew { get; set; }

        public string Director
        {
            get
            {
                return director;
            }
            set
            {
                if (value != director)
                {
                    director = value;
                    RaisePropertyChanged("Director");
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
        }

        public VMCompleteFilm()
        {
            Crew = new ObservableCollection<VMCrew>();
            Cast = new ObservableCollection<VMCast>();
            Genres = new ObservableCollection<string>();
        }
    }
}
