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
        public MainPage()
            : base()
        {
            InitializeComponent();
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
    }
}
