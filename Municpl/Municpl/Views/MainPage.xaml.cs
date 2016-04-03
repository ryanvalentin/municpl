using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Municpl.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;
using Windows.Phone.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Municpl.Views
{
    public sealed partial class MainPage : BaseNavigationAwarePage
    {
        public MainPage(Frame frame)
            : base()
        {
            InitializeComponent();
            mainPageSplitView.Content = frame;
        }

        public MainViewModel ViewModel
        {
            get
            {
                return DataContext as MainViewModel;
            }
        }

        private void agencyListHyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.NavigationService.NavigateTo(nameof(AgencyListPage));
        }

        private void menuRadioButton_Click(object sender, RoutedEventArgs e)
        {
            mainPageSplitView.IsPaneOpen = !mainPageSplitView.IsPaneOpen;
        }

        private void settingsRadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void actransitRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            ViewModel.Agencies.SelectedItem = ViewModel.Agencies.ACTransit;
            ViewModel.NavigationService.NavigateTo(nameof(RouteListPage));
        }

        private void caltrainRadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void bartRadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void muniRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            ViewModel.Agencies.SelectedItem = ViewModel.Agencies.SFMuni;
            ViewModel.NavigationService.NavigateTo(nameof(RouteListPage));
        }

        private void favoritesRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            ViewModel.NavigationService.NavigateTo(nameof(FavoritesPage));
        }
    }
}
