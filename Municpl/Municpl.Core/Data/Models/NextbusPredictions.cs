using System.Collections.Generic;

namespace Municpl.Core.Data.Models
{
    public class NextbusPredictions
    {
        public string AgencyTitle { get; set; }

        public string RouteTitle { get; set; }

        public string RouteTag { get; set; }

        public string StopTitle { get; set; }

        public string StopTag { get; set; }

        public List<NextbusPredictionsDirection> Directions { get; set; }

        public List<NextbusMessage> Messages { get; set; }
    }
}
