using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace SSO.Api.Filters
{
    ///<Summary>
    ///</Summary>
    public class AuthenticationFailureResult : IHttpActionResult
    {
        ///<Summary>
        ///</Summary>
        public AuthenticationFailureResult(string reasonPhrase, HttpRequestMessage request)
        {
            ReasonPhrase = reasonPhrase;
            Request = request;
        }

        ///<Summary>
        ///</Summary>
        public string ReasonPhrase { get; }

        ///<Summary>
        ///</Summary>
        public HttpRequestMessage Request { get; }

        ///<Summary>
        ///</Summary>
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(Execute());
        }

        private HttpResponseMessage Execute()
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Unauthorized)
            {
                RequestMessage = Request,
                ReasonPhrase = ReasonPhrase
            };

            return response;
        }
    }
}