using System.Collections.Generic;

namespace Municpl.Core.Data.Models
{
    public class NextbusStop : BaseNextbusModel
    {
        public string ShortTitle { get; set; }

        public GeoCoordinate Coordinates { get; set; }

        public int StopId { get; set; }

        public List<NextbusDirection> Directions { get; set; }

        public List<List<GeoCoordinate>> Paths { get; set; }
    }
}
