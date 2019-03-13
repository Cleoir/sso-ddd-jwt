using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace SSO.Api.Filters
{
    ///<Summary>
    ///</Summary>
    public class AddChallengeOnUnauthorizedResult : IHttpActionResult
    {
        ///<Summary>
        ///</Summary>
        public AddChallengeOnUnauthorizedResult(AuthenticationHeaderValue challenge, IHttpActionResult innerResult)
        {
            Challenge = challenge;
            InnerResult = innerResult;
        }

        ///<Summary>
        ///</Summary>
        public AuthenticationHeaderValue Challenge { get; }

        ///<Summary>
        ///</Summary>
        public IHttpActionResult InnerResult { get; }

        ///<Summary>
        ///</Summary>
        public async Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            HttpResponseMessage response = await InnerResult.ExecuteAsync(cancellationToken);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                // Only add one challenge per authentication scheme.
                if (response.Headers.WwwAuthenticate.All(h => h.Scheme != Challenge.Scheme))
                {
                    response.Headers.WwwAuthenticate.Add(Challenge);
                }
            }

            return response;
        }
    }
}