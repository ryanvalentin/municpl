using System;
using System.Collections.Generic;
using System.Text;

namespace Municpl.Core.Data.Models
{
    public class NextbusDirection : BaseNextbusModel
    {
        public string Name { get; set; }

        public bool UseForUI { get; set; }

        public List<NextbusStop> Stops { get; set; }
    }
}
