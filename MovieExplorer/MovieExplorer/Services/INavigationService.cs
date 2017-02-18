using MovieExplorer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieExplorer.Services
{
    public interface INavigationService
    {
        void NavigateToSecondPage(Object parameters);
        void NavigateToThirdPage(Object parameters);
        void GoBack();
    }
}
