using GalaSoft.MvvmLight.Views;
using Municpl.Views;
using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;

namespace Municpl.Core.Services
{
    public class MunicplNavigationService : INavigationService
    {
        private readonly Dictionary<string, Type> _keyPageTypeMapping;
        
        public MunicplNavigationService(Frame rootFrame)
        {
            RootFrame = rootFrame;
            _keyPageTypeMapping = new Dictionary<string, Type>();
        }

        public string CurrentPageKey { get; protected set; }

        public Frame RootFrame { get; set; }

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

        public void Configure(string pageKey, Type pageType)
        {
            _keyPageTypeMapping[pageKey] = pageType;
        }
    }
}
