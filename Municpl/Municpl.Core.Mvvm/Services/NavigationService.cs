using GalaSoft.MvvmLight.Views;
using Municpl.Views;
using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;

namespace Municpl.Core.Services
{
    /*
    public class NavigationService : INavigationService
    {
        public string CurrentPageKey { get; protected set; }

        public Frame RootFrame { get; set; }

        public NavigationService(Frame rootFrame)
        {
            RootFrame = rootFrame;
            _keyPageTypeMapping = new Dictionary<string, Type>();
        }

        public void GoBack()
        {
            if (RootFrame?.CanGoBack ?? false)
                RootFrame?.GoBack();
        }

        public void NavigateTo(string pageKey)
        {
            CurrentPageKey = pageKey;

            RootFrame?.Navigate(_keyPageTypeMapping[pageKey]);
        }

        public void NavigateTo(string pageKey, object parameter)
        {
            CurrentPageKey = pageKey;

            RootFrame?.Navigate(_keyPageTypeMapping[pageKey], parameter);
        }

        private readonly Dictionary<string, Type> _keyPageTypeMapping = new Dictionary<string, Type>()
        {
            { nameof(MainPage), typeof(MainPage) },
            { nameof(AgencyListPage), typeof(AgencyListPage) },
            { nameof(RouteListPage), typeof(RouteListPage) }
        };
    }
    */
}
