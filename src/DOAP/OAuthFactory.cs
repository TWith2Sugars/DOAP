//-----------------------------------------------------------------------
// <copyright file="OAuthFactory.cs" company="">
//    Copyright (c) Tony Williams 2010. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace DOAP
{
  using System;
  using System.Collections.Generic;
  using Provider;

  /// <summary>
  /// Helps to build an OAuth provider
  /// </summary>
  public static class OAuthFactory
  {
    /// <summary>
    /// The default time span expiration for an access token
    /// </summary>
    public static readonly TimeSpan DefaultAccessTokenExpirationTime = TimeSpan.FromHours(1);

    /// <summary>
    /// The default code authorisation expiration time span.
    /// </summary>
    public static readonly TimeSpan DefaultAuthorisationCodeExpirationTime = TimeSpan.FromMinutes(5);

    /// <summary>
    /// Builds the OAuth provider.
    /// </summary>
    /// <typeparam name="TClientIdentity">The type of the client identity.</typeparam>
    /// <typeparam name="TResourceOwner">The type of the resource owner.</typeparam>
    /// <param name="clientProvider">The client provider.</param>
    /// <param name="tokenProvider">The token provider.</param>
    /// <param name="supportedScopes">The supported scopes.</param>
    /// <param name="authorisationProvider">The authorisation provider.</param>
    /// <param name="passwordProvider">The resource owner provider.</param>
    /// <param name="assertionProvider">The assertion provider.</param>
    /// <param name="accessExpiration">The access expiration.</param>
    /// <param name="authorisationExpiration">The authorisation expiration.</param>
    /// <returns>An OAuth provider</returns>
    public static OAuthProvider<TClientIdentity, TResourceOwner> BuildOAuthProvider<TClientIdentity, TResourceOwner>(
      IClientProvider<TClientIdentity> clientProvider,
      ITokenProvider<TClientIdentity, TResourceOwner> tokenProvider,
      IEnumerable<string> supportedScopes,
      IAuthorisationProvider<TClientIdentity, TResourceOwner> authorisationProvider = null,
      IPasswordProvider<TResourceOwner> passwordProvider = null,
      IAssertionProvider<TResourceOwner> assertionProvider = null,
      TimeSpan? accessExpiration = null,
      TimeSpan? authorisationExpiration = null
      )
    {
      var supportedGrantTypes = new List<GrantType>
                                  {
                                    GrantType.None,
                                    GrantType.RefreshToken,
                                  };
      if (passwordProvider != null)
      {
        supportedGrantTypes.Add(GrantType.Password);
      }

      if (assertionProvider != null)
      {
        supportedGrantTypes.Add(GrantType.Assertion);
      }

      if(authorisationProvider != null)
      {
        supportedGrantTypes.Add(GrantType.AuthorizationCode);   
      }

      var supportedResponseTypes = new List<ResponseType>
                                     {
                                       ResponseType.Code,
                                       ResponseType.Token,
                                       ResponseType.CodeAndToken
                                     };

      var oauth = new OAuthProvider<TClientIdentity, TResourceOwner>(clientProvider,
                                                                     tokenProvider,
                                                                     authorisationProvider,
                                                                     passwordProvider,
                                                                     assertionProvider,
                                                                     supportedGrantTypes,
                                                                     supportedScopes,
                                                                     supportedResponseTypes,
                                                                     accessExpiration ??
                                                                     DefaultAccessTokenExpirationTime,
                                                                     authorisationExpiration ??
                                                                     DefaultAuthorisationCodeExpirationTime);

      return oauth;
    }
  }
}
