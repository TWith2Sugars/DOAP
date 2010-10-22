using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DOAP.Provider;

namespace DOAP.WCFExample.Provider
{
  public class TokenProvider: ITokenProvider<int, int>
  {
    private static readonly List<AccessToken<int,int>> accessTokens = new List<AccessToken<int, int>>();
 
    /// <summary>
    /// Generates a token (to be used as a token/auth code).
    /// </summary>
    /// <returns>The token</returns>
    public string GenerateToken()
    {
      return Guid.NewGuid().ToString();
    }

    /// <summary>
    /// Finds the access token.
    /// </summary>
    /// <param name="token">The token.</param>
    /// <returns>The access token associated with the parameter </returns>
    public AccessToken<int, int> FindAccessToken(string token)
    {
      var result = accessTokens.FirstOrDefault(x => x.Token == token);
      if(result == default(AccessToken<int,int>))
      {
        return null;
      }

      return result;
    }

    /// <summary>
    /// Finds the refresh token.
    /// </summary>
    /// <param name="token">The token.</param>
    /// <returns>The access token associated with the refresh token </returns>
    public AccessToken<int, int> FindRefreshToken(string token)
    {
      var result = accessTokens.FirstOrDefault(x => x.RefreshToken == token);
      if (result == default(AccessToken<int, int>))
      {
        return null;
      }

      return result;
    }

    /// <summary>
    /// Stores the access token.
    /// </summary>
    /// <param name="token">The token.</param>
    public void StoreAccessToken(AccessToken<int, int> token)
    {
      accessTokens.Add(token);
    }

    /// <summary>
    /// Expires the access token.
    /// </summary>
    /// <param name="token">The token.</param>
    public void ExpireAccessToken(AccessToken<int, int> token)
    {
      accessTokens.Remove(token);
    }
  }
}