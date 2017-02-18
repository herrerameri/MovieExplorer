using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MovieExplorer.Services;

namespace MovieExplorer.ViewModels.Base
{
    public class VMLocator
    {
        private Lazy<VMMain> mainViewModel;
        private Lazy<VMSecond> secondViewModel;
        private Lazy<VMThird> thirdViewModel;
        private INavigationService navigationService;

        public VMLocator()
        {
            navigationService = new NavigationService();

            mainViewModel = new Lazy<VMMain>(() => new VMMain(navigationService));
            secondViewModel = new Lazy<VMSecond>(() => new VMSecond(navigationService));
            thirdViewModel = new Lazy<VMThird>(() => new VMThird(navigationService));
        }

        public VMMain MainViewModel
        {
            get
            {
                return mainViewModel.Value;
            }
        }

        public VMSecond SecondViewModel
        {
            get
            {
                return secondViewModel.Value;
            }
        }
        public VMThird ThirdViewModel
        {
            get
            {
                return thirdViewModel.Value;
            }
        }
    }
}
