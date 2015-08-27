using System;

namespace Municpl.Core.Data.Services
{
    public class DataEngineErrorEventArgs : EventArgs
    {
        public DataEngineErrorEventArgs()
        {

        }

        public string Error { get; set; }

        public DataEngineType EngineType { get; set; }
    }
}
