using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using Municpl.Core.Data.Services;
using Municpl.Core.Services;
using Municpl.Views;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Municpl.Core.ViewModels
{
    public class ViewModelLocator
    {
        public MainViewModel Main
        {
            get { return ServiceLocator.Current.GetInstance<MainViewModel>(); }
        }

        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            // Register service dependencies injected with each ViewModel
            SimpleIoc.Default.Register<INextbusDataService, NextbusDataService>(true);
            SimpleIoc.Default.Register(() => CreateNavigationService());

            // Register the actual view models
            SimpleIoc.Default.Register<MainViewModel>();
        }

        private static INavigationService CreateNavigationService()
        {
            var navigationService = new MunicplNavigationService(App.RootFrame);
            navigationService.Configure(nameof(MainPage), typeof(MainPage));
            navigationService.Configure(nameof(FavoritesPage), typeof(FavoritesPage));
            navigationService.Configure(nameof(AgencyListPage), typeof(AgencyListPage));
            navigationService.Configure(nameof(RouteListPage), typeof(RouteListPage));
            // TODO add additional views here

            return navigationService;
        }
    }
}
