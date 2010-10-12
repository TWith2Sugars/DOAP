//-----------------------------------------------------------------------
// <copyright file="AccessToken.cs" company="">
//    Copyright (c) Tony Williams 2010. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace DOAP
{
  using System;
  using System.Collections.Generic;

  /// <summary>
  /// An access token for a resource granted by a resource owner to a client
  /// </summary>
  /// <typeparam name="TClientIdentity">The type of the client identity.</typeparam>
  /// <typeparam name="TResourceOwnerIdentity">The type of the resource owner identity.</typeparam>
  public class AccessToken<TClientIdentity, TResourceOwnerIdentity>
  {
    /// <summary>
    /// Gets or sets the client id.
    /// </summary>
    /// <value>The client id.</value>
    public TClientIdentity ClientId { get; set; }

    /// <summary>
    /// Gets or sets the resource owner id.
    /// </summary>
    /// <value>The resource owner id.</value>
    public TResourceOwnerIdentity ResourceOwnerId { get; set; }

    /// <summary>
    /// Gets or sets the expires.
    /// </summary>
    /// <value>The expires.</value>
    public DateTime? Expires { get; set; }

    /// <summary>
    /// Gets or sets the time stamp.
    /// </summary>
    /// <value>The time stamp.</value>
    public DateTime TimeStamp { get; set; }

    /// <summary>
    /// Gets or sets the scope.
    /// </summary>
    /// <value>The scope.</value>
    public IEnumerable<string> Scope { get; set; }

    /// <summary>
    /// Gets or sets the refresh token.
    /// </summary>
    /// <value>The refresh token.</value>
    public string RefreshToken { get; set; }

    /// <summary>
    /// Gets or sets the token.
    /// </summary>
    /// <value>The token.</value>
    public string Token { get; set; }
  }
}
