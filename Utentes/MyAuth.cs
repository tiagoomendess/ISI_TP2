using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.ServiceModel.Web;
using System.Web;
using DevDefined.OAuth.Consumer;

namespace Utentes
{
    public class MyAuth
    {
        public static bool Authenticate(IncomingWebRequestContext context)

        {
            bool Authenticated = false;

            string normalizedUrl;
            string normalizedRequestParameters;

            //context.Headers
            NameValueCollection pa = context.UriTemplateMatch.QueryParameters;

            if (pa != null && pa["oauth_consumer_key"] != null)
            {
                // to get uri without oauth parameters
                string uri = context.UriTemplateMatch.RequestUri.OriginalString.Replace
                    (context.UriTemplateMatch.RequestUri.Query, "");

                string consumersecret = "segredo";

                OAuthBase oauth = new OAuthBase();

                string hash = oauth.GenerateSignature(
                    new Uri(uri),
                    pa["oauth_consumer_key"],
                    consumersecret,
                    string.Empty, // totken
                    string.Empty, //token secret
                    "GET",
                    pa["oauth_timestamp"],
                    pa["oauth_nonce"],
                    out normalizedUrl,
                    out normalizedRequestParameters
                    );

                Authenticated = pa["oauth_signature"] == hash;
            }

            return Authenticated;
        }

    }
}