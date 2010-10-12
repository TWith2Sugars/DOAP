//-----------------------------------------------------------------------
// <copyright file="AccessTokenResponse.cs" company="">
//    Copyright (c) Tony Williams 2010. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace DOAP.Response
{
  /// <summary>
  /// A response for when requesting an access token
  /// </summary>
  /// <typeparam name="TClientIdentity">The type of the client identity.</typeparam>
  /// <typeparam name="TResourceOwnerIdentity">The type of the resource owner identity.</typeparam>
  public class AccessTokenResponse<TClientIdentity, TResourceOwnerIdentity> : Response
  {
    /// <summary>
    /// Gets or sets the access token.
    /// </summary>
    /// <value>The access token.</value>
    public AccessToken<TClientIdentity, TResourceOwnerIdentity> AccessToken { get; set; }
  }
}
