using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieExplorer.ViewModels.Base;

namespace MovieExplorer.ViewModels
{
    public class VMSeason : VMBase
    {
        private string number;
        private string poster;
        private string airDate;

        public string Number
        {
            get { return string.Format("Number {0}", number); }
            set
            {
                if (value != number)
                {
                    number = value;
                    RaisePropertyChanged("Number");
                }
            }
        }
        public string Poster
        {
            get { return poster; }
            set
            {
                if (value != poster)
                {
                    poster = value;
                    RaisePropertyChanged("Poster");
                }
            }
        }
        public string AirDate
        {
            get { return string.Format("Air {0}", airDate); }
            set
            {
                if (value != airDate)
                {
                    airDate = value;
                    RaisePropertyChanged("AirDate");
                }
            }
        }
    }
}
