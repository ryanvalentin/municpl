using System.Collections.Generic;

namespace Municpl.Core.Data.Models
{
    public class NextbusDirection : BaseNextbusModel
    {
        public string Name { get; set; }

        public bool UseForUI { get; set; }

        public List<NextbusStop> Stops { get; set; }
    }
}
