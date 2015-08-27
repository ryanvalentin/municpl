using System.Collections.Generic;

namespace Municpl.Core.Data.Models
{
    public class NextbusRoute : BaseNextbusModel
    {
        public string Color { get; set; }

        public string OppositeColor { get; set; }

        public GeoCoordinate MinimumCoordinates { get; set; }

        public GeoCoordinate MaximumCoordinates { get; set; }

        public List<NextbusStop> Stops { get; set; }

        public List<NextbusDirection> Directions { get; set; }

        public List<List<GeoCoordinate>> Paths { get; set; }
    }
}
