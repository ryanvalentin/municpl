using System.Collections.Generic;

namespace Municpl.Core.Data.Models
{
    public class NextbusPrediction
    {
        public long EpochTime { get; set; }

        public int Seconds { get; set; }

        public int Minutes { get; set; }

        public bool IsDeparture { get; set; }

        public string DirectionTag { get; set; }

        public int Vehicle { get; set; }

        public string Block { get; set; }

        public string TripTag { get; set; }

        public int VehiclesInConsist { get; set; }
     }
}
