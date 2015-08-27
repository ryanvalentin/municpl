using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
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
            var agencies = await NextbusDataService.AgencyListAsync();

            foreach (var nextbusAgency in agencies)
                response.Add(new AgencyItemViewModel(nextbusAgency));

            return response;
        }
    }
}
