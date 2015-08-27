namespace Municpl.Core.Data.Models
{
    public class NextbusStop : BaseNextbusModel
    {
        public string ShortTitle { get; set; }

        public GeoCoordinate Coordinates { get; set; }

        public int StopId { get; set; }
    }
}
