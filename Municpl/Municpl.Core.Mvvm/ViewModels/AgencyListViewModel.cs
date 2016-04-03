using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Municpl.Core.Data.Models;
using Municpl.Core.Data.Services;
using Municpl.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Municpl.Core.ViewModels
{
    public class AgencyListViewModel : MunicplBaseListViewModel<AgencyItemViewModel>, IMunicplViewModel
    {
        public AgencyListViewModel()
            : base("agencies", "Transit Agencies")
        {

        }

        public override void Initialize(object parameter)
        {
            GetItemsAsync().ContinueWith((task) => { return; }, TaskContinuationOptions.OnlyOnFaulted);
        }

        protected override async Task<IEnumerable<AgencyItemViewModel>> GetItemsAsync()
        {
            List<AgencyItemViewModel> response = new List<AgencyItemViewModel>();

            SFMuni = new AgencyItemViewModel(new NextbusAgency()
            {
                Tag = AgencyItemViewModel.SFMuniId,
                ShortTitle = "SF Muni",
                Title = "San Francisco Muni",
                RegionTitle = "California-Northern"
            });
            response.Add(SFMuni);

            Bart = new AgencyItemViewModel(null) // TODO allow setting of other data classes
            {
                Title = "BART",
                Id = AgencyItemViewModel.BartId
            };
            response.Add(Bart);

            ACTransit = new AgencyItemViewModel(new NextbusAgency()
            {
                Tag = AgencyItemViewModel.ACTransitId,
                Title = "AC Transit",
                RegionTitle = "California-Northern"
            });
            response.Add(ACTransit);

            Caltrain = new AgencyItemViewModel(null)
            {
                Title = "Caltrain",
                Id = AgencyItemViewModel.CaltrainId
            };
            response.Add(Caltrain);

            // TODO we can probably add the other northern CA agencies

            return await Task.FromResult(response);
        }

        private AgencyItemViewModel _sfMuni;
        public AgencyItemViewModel SFMuni
        {
            get { return _sfMuni; }
            set { Set(nameof(SFMuni), ref _sfMuni, value); }
        }

        private AgencyItemViewModel _bart;
        public AgencyItemViewModel Bart
        {
            get { return _bart; }
            set { Set(nameof(Bart), ref _bart, value); }
        }

        private AgencyItemViewModel _acTransit;
        public AgencyItemViewModel ACTransit
        {
            get { return _acTransit; }
            set { Set(nameof(ACTransit), ref _acTransit, value); }
        }

        private AgencyItemViewModel _caltrain;
        public AgencyItemViewModel Caltrain
        {
            get { return _caltrain; }
            set { Set(nameof(Caltrain), ref _caltrain, value); }
        }
    }
}
