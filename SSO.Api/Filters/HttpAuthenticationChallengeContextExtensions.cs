using System;
using System.Net.Http.Headers;
using System.Web.Http.Filters;

namespace SSO.Api.Filters
{
    ///<Summary>
    ///</Summary>
    public static class HttpAuthenticationChallengeContextExtensions
    {
        ///<Summary>
        ///</Summary>
        public static void ChallengeWith(this HttpAuthenticationChallengeContext context, string scheme)
        {
            ChallengeWith(context, new AuthenticationHeaderValue(scheme));
        }

        ///<Summary>
        ///</Summary>
        public static void ChallengeWith(this HttpAuthenticationChallengeContext context, string scheme, string parameter)
        {
            ChallengeWith(context, new AuthenticationHeaderValue(scheme, parameter));
        }

        ///<Summary>
        ///</Summary>
        public static void ChallengeWith(this HttpAuthenticationChallengeContext context, AuthenticationHeaderValue challenge)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            context.Result = new AddChallengeOnUnauthorizedResult(challenge, context.Result);
        }
    }
}