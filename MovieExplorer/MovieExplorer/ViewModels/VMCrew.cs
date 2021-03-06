﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieExplorer.ViewModels.Base;

namespace MovieExplorer.ViewModels
{
    public class VMCrew : VMBase
    {
        private string name;
        private string department;
        private string job;
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
        public string Department
        {
            get { return department; }
            set
            {
                if (value != department)
                {
                    department = value;
                    RaisePropertyChanged("Department");
                }
            }
        }
        public string Job
        {
            get { return job; }
            set
            {
                if (value != job)
                {
                    job = value;
                    RaisePropertyChanged("Job");
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
