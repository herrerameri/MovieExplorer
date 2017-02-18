using MovieExplorer.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieExplorer.ViewModels
{
    public class VMItemFilm : VMBase
    {
        private int id;
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                if (value != id)
                {
                    id = value;
                    RaisePropertyChanged("Id");
                }
            }
        }

        private string title;
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                if (value != title)
                {
                    title = value;
                    RaisePropertyChanged("Title");
                }
            }
        }

        private string description;
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                if (value != description)
                {
                    description = value;
                    RaisePropertyChanged("Description");
                }
            }
        }

        private int year;
        public int Year
        {
            get
            {
                return year;
            }
            set
            {
                if (value != year)
                {
                    year = value;
                    RaisePropertyChanged("Year");
                }
            }
        }

        private string poster;
        public string Poster
        {
            get
            {
                return poster;
            }
            set
            {
                if (value != poster)
                {
                    poster = value;
                    RaisePropertyChanged("Poster");
                }
            }
        }

        public string TitleAndDate
        {
            get
            {
                return string.Format("{0} ({1})", Title, Year.ToString());
            }
        }
    }
}
