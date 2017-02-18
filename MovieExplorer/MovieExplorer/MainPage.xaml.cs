using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using MovieExplorer.ViewModels;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MovieExplorer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void LVFMovies_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           ((VMMain) DataContext).OnSelectedItemFilm((VMItemFilm)LVFMovies.SelectedItem);
        }
        private void LVFTVShow_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ((VMMain)DataContext).OnSelectedItemTvShow((VMItemTvShow)LVFTVShow.SelectedItem);
        }

        private void PivotMoviesTvShow_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var pivot = PivotMoviesTvShow.SelectedIndex;
            ((VMMain)DataContext).SetVisiblePivot(pivot);
        }
    }
}
