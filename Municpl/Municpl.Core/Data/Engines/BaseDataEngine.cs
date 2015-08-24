using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;

namespace Municpl.Core.Data.Engines
{
    public class BaseDataEngine
    {
        protected readonly HttpClient _httpClient;

        protected BaseDataEngine()
        {
            // TODO use gzip handler

            _httpClient = new HttpClient();
        }
    }
}
