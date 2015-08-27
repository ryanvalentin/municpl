using System;
using System.Collections.Generic;
using System.Text;

namespace Municpl.Core.Data.Models
{
    public class NextbusPredictionsDirection
    {
        public string Title { get; set; }

        public List<NextbusPrediction> Predictions { get; set; }
    }
}
