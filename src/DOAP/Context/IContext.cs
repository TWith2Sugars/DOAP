//-----------------------------------------------------------------------
// <copyright file="ITokenContext.cs" company="">
//    Copyright (c) Tony Williams 2010. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace DOAP.Context
{
  using System;
  using System.Collections.Generic;

  /// <summary>
  /// The base context interface that define common properties of other contexts
  /// </summary>
  /// <typeparam name="TClientIdentity">The type of the client identity.</typeparam>
  public interface IContext<out TClientIdentity>
  {
    /// <summary>
    /// Gets the client id.
    /// </summary>
    /// <value>The client id.</value>
    TClientIdentity ClientId { get; }

    /// <summary>
    /// Gets the scope.
    /// </summary>
    /// <value>The scope.</value>
    IEnumerable<string> Scope { get; }

    /// <summary>
    /// Gets the redirect URI.
    /// </summary>
    /// <value>The redirect URI.</value>
    Uri RedirectUri { get; }
  }
}
