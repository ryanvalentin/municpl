using Municpl.Core.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml.Media;
using System.Linq;

namespace Municpl.Core.ViewModels
{
    public class RouteItemViewModel : MunicplBaseViewModel, IMunicplViewModel
    {
        public RouteItemViewModel(NextbusRoute routeData, string agencyId)
            : base(routeData?.Tag, routeData?.Title)
        {
            if (agencyId == AgencyItemViewModel.SFMuniId)
                ParseMuniRoute(routeData);

        }

        private void ParseMuniRoute(NextbusRoute routeData)
        {
            if (routeData.Title.Contains("-"))
                Title = routeData.Title.Split(new char[] { '-' }, 2)[1];

            if (new string[] { "59, 60, 61" }.Any(routeData.Tag.Contains))
            {
                // Cable Car lines
                IconText = "CC";
                Color = _routeColorDictionary["CC"];
            }
            else if (routeData.Tag.Contains("_OWL"))
            {
                // OWL Lines
                Color = _routeColorDictionary["OWL"];
                IconText = routeData.Tag.Replace("_", "");
                Title = routeData.Title;
            }
            else
            {
                IconText = routeData.Tag;

                if (_routeColorDictionary.ContainsKey(IconText))
                    Color = _routeColorDictionary[IconText];
                else if (IconText.EndsWith("X"))
                    Color = _routeColorDictionary["X"];
                else if (IconText.EndsWith("R"))
                    Color = _routeColorDictionary["R"];
                else
                    Color = _routeColorDictionary["Local"];
            }            
        }

        private string _color = "#0DA5FF";
        public string Color
        {
            get { return _color; }
            set { Set(ref _color, value); }
        }

        private string _iconText;
        public string IconText
        {
            get { return _iconText; }
            set { Set(ref _iconText, value); }
        }

        private readonly Dictionary<string, string> _routeColorDictionary = new Dictionary<string, string>()
        {
            { "F", "#555555" },
            { "J", "#cc6600" },
            { "KT", "#cc0033" },
            { "L", "#660099" },
            { "M", "#006633" },
            { "N", "#003399" },
            { "Local", "#0DA5FF" }, // Generic local bus color
            { "R", "#6E0CE8" }, // Limited bus color
            { "X", "#FF0000" }, // Express bus color
            { "CC", "#E88D0C" }, // Cable car color
            { "OWL", "#173BFF" } // Owl color
        };

    }
}
