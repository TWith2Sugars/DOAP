//-----------------------------------------------------------------------
// <copyright file="ITokenProvider.cs" company="">
//    Copyright (c) Tony Williams 2010. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace DOAP.Provider
{
  /// <summary>
  /// Defines what a token provider is required to do (mainly generate/find/store tokens)
  /// </summary>
  /// <typeparam name="TClientIdentity">The type of the client identity.</typeparam>
  /// <typeparam name="TResourceOwnerIdentity">The type of the resource owner identity.</typeparam>
  public interface ITokenProvider<TClientIdentity, TResourceOwnerIdentity>
  {
    /// <summary>
    /// Generates a token (to be used as a token/auth code).
    /// </summary>
    /// <returns>The token</returns>
    string GenerateToken();

    /// <summary>
    /// Finds the access token.
    /// </summary>
    /// <param name="token">The token.</param>
    /// <returns>The access token associated with the parameter </returns>
    AccessToken<TClientIdentity, TResourceOwnerIdentity> FindAccessToken(string token);

    /// <summary>
    /// Finds the refresh token.
    /// </summary>
    /// <param name="token">The token.</param>
    /// <returns>The access token associated with the refresh token </returns>
    AccessToken<TClientIdentity, TResourceOwnerIdentity> FindRefreshToken(string token);

    /// <summary>
    /// Stores the access token.
    /// </summary>
    /// <param name="token">The token.</param>
    void StoreAccessToken(AccessToken<TClientIdentity, TResourceOwnerIdentity> token);

    /// <summary>
    /// Expires the access token.
    /// </summary>
    /// <param name="token">The token.</param>
    void ExpireAccessToken(AccessToken<TClientIdentity, TResourceOwnerIdentity> token);
  }
}
