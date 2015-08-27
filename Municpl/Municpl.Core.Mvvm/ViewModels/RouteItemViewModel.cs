using Municpl.Core.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Municpl.Core.ViewModels
{
    public class RouteItemViewModel : MunicplBaseViewModel, IMunicplViewModel
    {
        public RouteItemViewModel(NextbusRoute routeData)
            : base(routeData?.Tag, routeData?.Title)
        {

        }
    }
}
