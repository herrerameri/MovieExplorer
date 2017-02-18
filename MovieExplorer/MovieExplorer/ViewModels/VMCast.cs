using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieExplorer.ViewModels.Base;

namespace MovieExplorer.ViewModels
{
    public class VMCast : VMBase
    {
        private string name;
        private string character;
        private string picture;

        public string Name
        {
            get { return name; }
            set
            {
                if (value != name)
                {
                    name = value;
                    RaisePropertyChanged("Name");
                }
            }
        }
        public string Character
        {
            get { return character; }
            set
            {
                if (value != character)
                {
                    character = value;
                    RaisePropertyChanged("Character");
                }
            }
        }
        public string Picture
        {
            get { return picture; }
            set
            {
                if (value != picture)
                {
                    picture = value;
                    RaisePropertyChanged("Picture");
                }
            }
        }
    }
}
