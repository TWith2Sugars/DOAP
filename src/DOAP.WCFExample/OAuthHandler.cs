

using System.Collections.Generic;
using System.Net;
using System.ServiceModel;
using System.Web;
using DOAP.Provider;
using DOAP.WCF;
using DOAP.WCFExample.Provider;
using WcfRestContrib.ServiceModel.Web.Exceptions;

namespace DOAP.WCFExample
{
  using System.IdentityModel.Selectors;
  using System.Security.Principal;
  using System.ServiceModel.Web;
  using WcfRestContrib.ServiceModel.Dispatcher;

  public class OAuthHandler : IOAuthAuthenticationHandler
  {
    /// <summary>
    /// Authenticates the specified request.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <param name="response">The response.</param>
    /// <param name="parameters">The parameters.</param>
    /// <param name="secure">if set to <c>true</c> [secure].</param>
    /// <param name="requiresTransportLayerSecurity">if set to <c>true</c> [requires transport layer security].</param>
    /// <param name="scope">The scope.</param>
    /// <returns></returns>
    public IIdentity Authenticate(IncomingWebRequestContext request, OutgoingWebResponseContext response, object[] parameters, bool secure, bool requiresTransportLayerSecurity, string scope, bool allowAnonymous)
    {
      var clientProvider = new ClientProvider();
      var passwordProvider = new PasswordProvider();
      var tokenProvider = new TokenProvider();
      var scopes = new List<string>();

      var oAuthProvider = OAuthFactory.BuildOAuthProvider(clientProvider, tokenProvider, scopes, passwordProvider: passwordProvider);

      var token = request.Headers["Authorization"];
      if (string.IsNullOrWhiteSpace(token))
      {
        token = HttpContext.Current.Request.QueryString["access_token"];
      }
      else
      {
        if (!string.IsNullOrWhiteSpace(token) && token.StartsWith("OAuth") && token.Contains(" "))
        {
          var splitToken = token.Split(' ');
          if (splitToken.Length > 1)
          {
            token = splitToken[1];
          }
        }
      }

      var authentication = oAuthProvider.VerifyToken(token, scope);
      if (authentication.ErrorCode != ErrorCode.None)
      {
        if (allowAnonymous)
        {
          return null;
        }

        var errorCode = authentication.StatusCode();
        var oauthError = authentication.Error();
        if (errorCode == HttpStatusCode.Unauthorized)
        {
          response.Headers.Add(HttpResponseHeader.WwwAuthenticate, string.Format("OAuth realm='PollMe Service', error='{0}'", oauthError));
        }

        throw new WebFaultException<string>(oauthError, authentication.StatusCode());
      }

      return new GenericIdentity("Authorised User", "OAuth2");
    }
  }
}