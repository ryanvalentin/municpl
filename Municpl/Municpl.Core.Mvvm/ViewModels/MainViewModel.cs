using GalaSoft.MvvmLight.Views;
using Municpl.Core.Data.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Municpl.Core.ViewModels
{
    public class MainViewModel : MunicplBaseViewModel, IMunicplViewModel
    {
        private INextbusDataService _nextbusDataService;

        public MainViewModel(INextbusDataService nextbusDataService, INavigationService navigationService)
            : base("main", "Municpl", navigationService)
        {
            _nextbusDataService = nextbusDataService;

            Favorites = new FavoritesListViewModel();
            Agencies = new AgencyListViewModel();
            Agencies.Initialize(null);
        }

        private FavoritesListViewModel _favorites;
        public FavoritesListViewModel Favorites
        {
            get { return _favorites; }
            set { Set(nameof(Favorites), ref _favorites, value); }
        }

        private AgencyListViewModel _agencies;
        public AgencyListViewModel Agencies
        {
            get { return _agencies; }
            set { Set(nameof(Agencies), ref _agencies, value); }
        }
    }
}
