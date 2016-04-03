using Municpl.Core.Data.Services;
using Municpl.Core.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Municpl.Core.ViewModels
{
    public class RouteListViewModel : MunicplBaseListViewModel<RouteItemViewModel>, IMunicplViewModel
    {
        public RouteListViewModel(NextbusAgency agencyData = null)
            : base(agencyData?.Tag, agencyData?.Title)
        {
        }

        protected override async Task<IEnumerable<RouteItemViewModel>> GetItemsAsync()
        {
            List<RouteItemViewModel> response = new List<RouteItemViewModel>();
            var routes = await NextbusDataService.RouteListAsync(Id);

            foreach (var route in routes)
                response.Add(new RouteItemViewModel(route, Id));

            return response;
        }
    }
}
