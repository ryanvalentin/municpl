﻿using Municpl.Core.Data.Services;
using Municpl.Core.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using GalaSoft.MvvmLight.Command;
using Municpl.Views;

namespace Municpl.Core.ViewModels
{
    public class AgencyItemViewModel : MunicplBaseViewModel, IMunicplViewModel
    {
        public const string SFMuniId = "sf-muni";
        public const string ACTransitId = "actransit";
        public const string CaltrainId = "caltrain";
        public const string BartId = "bart";

        public AgencyItemViewModel(NextbusAgency agencyData)
            : base(agencyData?.Tag, agencyData?.Title)
        {
            Routes = new RouteListViewModel(agencyData);
        }

        private RouteListViewModel _routes;
        public RouteListViewModel Routes
        {
            get { return _routes; }
            set { Set(nameof(Routes), ref _routes, value); }
        }
    }
}
