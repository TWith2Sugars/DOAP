//-----------------------------------------------------------------------
// <copyright file="AccessTokenResponse.cs" company="">
//    Copyright (c) Tony Williams 2010. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace DOAP.Response
{
  using System;
  using System.Collections.Generic;

  /// <summary>
  /// A response for when an authorisation request is made
  /// </summary>
  /// <typeparam name="TClientIdentity">The type of the client identity.</typeparam>
  public class AuthorisationResponse<TClientIdentity> : Response
  {
    /// <summary>
    /// Gets or sets the client.
    /// </summary>
    /// <value>The client.</value>
    public IClient<TClientIdentity> Client { get; set; }

    /// <summary>
    /// Gets or sets the scope.
    /// </summary>
    /// <value>The scope.</value>
    public IEnumerable<string> Scope { get; set; }

    /// <summary>
    /// Gets or sets the redirect URI.
    /// </summary>
    /// <value>The redirect URI.</value>
    public Uri RedirectUri { get; set; }

    /// <summary>
    /// Gets or sets the state.
    /// </summary>
    /// <value>The state.</value>
    public string State { get; set; }
  }
}
