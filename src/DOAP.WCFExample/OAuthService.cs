using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Web;
using DOAP.Context;
using DOAP.Response;
using DOAP.WCFExample.Provider;

namespace DOAP.WCFExample
{
  [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
  [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
  [ServiceContract]
  public class OAuthService 
  {
    private readonly OAuthProvider<int, int> oAuthProvider;

    /// <summary>
    /// Initializes a new instance of the <see cref="OAuthService"/> class.
    /// </summary>
    public OAuthService()
    {
      var clientProvider = new ClientProvider();
      var tokenProvider = new TokenProvider();
      var passwordProvider = new PasswordProvider();
      
      
      var scopes = new List<string>();

      this.oAuthProvider = OAuthFactory.BuildOAuthProvider(clientProvider, tokenProvider, scopes, passwordProvider: passwordProvider);
    }

    [WebInvoke(UriTemplate = "token", Method = "POST"), OperationContract]
    public OAuthResponse Token()
    {
      var context = new HttpOAuthContext<int>(HttpContext.Current);
      var accessToken = this.oAuthProvider.GrantAccessToken(context);
      WebOperationContext.Current.OutgoingResponse.StatusCode = accessToken.StatusCode();
      WebOperationContext.Current.OutgoingResponse.Format = WebMessageFormat.Json;
      WebOperationContext.Current.OutgoingResponse.Headers["Cache-Control"] = "no-store";
      var response = new OAuthResponse();
      if (accessToken.ErrorCode == ErrorCode.None)
      {
        response.AccessToken = accessToken.AccessToken.Token;
        response.RefreshToken = accessToken.AccessToken.RefreshToken;
        if (accessToken.AccessToken.Expires.HasValue)
        {
          response.ExpiresIn =
            (int)(accessToken.AccessToken.Expires.Value - accessToken.AccessToken.TimeStamp).TotalSeconds;
        }

      }
      else
      {
        response.Error = accessToken.Error();
      }

      return response;
    }
  }
}