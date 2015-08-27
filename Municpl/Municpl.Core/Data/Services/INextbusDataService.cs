using Municpl.Core.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Municpl.Core.Data.Services
{
    public interface INextbusDataService
    {
        Task<List<NextbusAgency>> AgencyListAsync();

        Task<List<NextbusRoute>> RouteListAsync(string agencyTag);

        Task<NextbusRoute> RouteConfigAsync(string agencyTag, string routeTag);

        Task<NextbusPredictions> PredictionsAsync(string agencyTag, string routeTag, string stopTag, bool useShortTitles = true);

        Task<List<NextbusPredictions>> PredictionsForMultiStopsAsync(string agencyTag, List<KeyValuePair<string, string>> routeTagStopTagPairs, bool useShortTitles = true);
    }
}
