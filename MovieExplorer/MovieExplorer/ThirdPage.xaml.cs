using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System.Profile;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using MovieExplorer.ViewModels;
using System.ComponentModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MovieExplorer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ThirdPage : Page
    {
        public INotifyPropertyChanged vmThird;

        public ThirdPage()
        {
            
            this.InitializeComponent();
            this.InitializeStatusBar();
            var size = Window.Current.Bounds;

            if (size.Width <= 600)
            {
                Description.Width = size.Width - 20;
                Cast.Width = size.Width - 20;
                Crew.Width = size.Width - 20;
            }
            else
            {
                Description.Width = 600 - 20;
                Cast.Width = 600 - 20;
                Crew.Width = 600 - 20;
            }
        }

        public void InitializeNotificaciones(INotifyPropertyChanged notify)
        {
            vmThird = notify;
            vmThird.PropertyChanged +=
                  new PropertyChangedEventHandler(manageProgressBar);
        }

        private void manageProgressBar(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SHOW")
            {
                showProgressBar();
            }
            else
            {
                hideProgressBar();
            }
        }

        private void InitializeStatusBar()
        {
            AnalyticsVersionInfo ai = AnalyticsInfo.VersionInfo;
            string systemFamily = ai.DeviceFamily;

            if (systemFamily == "Windows.Mobile")
            {
                StatusBar statusBar = StatusBar.GetForCurrentView();
                statusBar.BackgroundColor = Colors.Black;
                statusBar.ForegroundColor = Colors.White;
                statusBar.BackgroundOpacity = 100;
            }
        }       

        public async void showProgressBar()
        {
            AnalyticsVersionInfo ai = AnalyticsInfo.VersionInfo;
            string systemFamily = ai.DeviceFamily;

            if (systemFamily == "Windows.Mobile")
            {
                StatusBar statusBar = Windows.UI.ViewManagement.StatusBar.GetForCurrentView();
                await statusBar.ProgressIndicator.ShowAsync();
            }
        }

        public async void hideProgressBar()
        {
            AnalyticsVersionInfo ai = AnalyticsInfo.VersionInfo;
            string systemFamily = ai.DeviceFamily;

            if (systemFamily == "Windows.Mobile")
            {
                StatusBar statusBar = Windows.UI.ViewManagement.StatusBar.GetForCurrentView();
                await statusBar.ProgressIndicator.HideAsync();
            }
        }

    }
}
