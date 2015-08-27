using System;
using System.Net;
using System.Net.Http;

namespace Municpl.Core.Data.Services
{
    public class BaseDataService
    {
        protected readonly HttpClient _httpClient;

        protected BaseDataService()
        {
            var handler = new HttpClientHandler();
            if (handler.SupportsAutomaticDecompression)
                handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            _httpClient = new HttpClient(handler);
            _httpClient.Timeout = TimeSpan.FromSeconds(5);
        }

        public delegate void DataEngineErrorHandler(object sender, DataEngineErrorEventArgs args);

        public event DataEngineErrorHandler OnError;

        protected void RaiseError(DataEngineType engineType, string message)
        {
            System.Diagnostics.Debug.WriteLine(String.Format("[{0}] {1}", engineType, message));

            if (OnError != null)
            {
                OnError(this, new DataEngineErrorEventArgs()
                {
                    EngineType = engineType,
                    Error = message
                });
            }
        }
    }
}
