using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCServer.Api.Infrastructure
{
    public class ReleaseResource : IDisposable
    {
        private readonly Action _release;

        public ReleaseResource(Action release)
        {
            _release = release;
        }

        public void Dispose()
        {
            _release();
        }
    }
}
