using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace SCServer.Common.Helpers
{
    public static class ExceptionHelper
    {
        public static void ThrowApiException(HttpStatusCode httpStatusCode, string reasonPhrase, string content)
        {
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage(httpStatusCode);

            httpResponseMessage.ReasonPhrase = reasonPhrase;
            httpResponseMessage.Content = new StringContent(content);

            throw new HttpResponseException(httpResponseMessage);
        }

        public static Exception GetApiException(HttpStatusCode httpStatusCode, string reasonPhrase, string content)
        {
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage(httpStatusCode);

            httpResponseMessage.ReasonPhrase = reasonPhrase;
            httpResponseMessage.Content = new StringContent(content);

            return new HttpResponseException(httpResponseMessage);
        }
    }
}
