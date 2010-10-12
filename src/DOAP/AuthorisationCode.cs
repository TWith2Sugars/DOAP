//-----------------------------------------------------------------------
// <copyright file="AuthorisationCode.cs" company="">
//    Copyright (c) Tony Williams 2010. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace DOAP
{
  using System;
  using System.Collections.Generic;

  /// <summary>
  /// An authorisation code.
  /// </summary>
  /// <typeparam name="TClientIdentity">The type of the client identity.</typeparam>
  /// <typeparam name="TResourceOwnerIdentity">The type of the resource owner identity.</typeparam>
  public class AuthorisationCode<TClientIdentity, TResourceOwnerIdentity>
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
    /// Gets or sets the redirect URI.
    /// </summary>
    /// <value>The redirect URI.</value>
    public Uri RedirectUri { get; set; }

    /// <summary>
    /// Gets or sets the expires.
    /// </summary>
    /// <value>The expires.</value>
    public DateTime Expires { get; set; }

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
    /// Gets or sets the code.
    /// </summary>
    /// <value>The code.</value>
    public string Code { get; set; }
  }
}
