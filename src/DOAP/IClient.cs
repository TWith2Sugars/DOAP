//-----------------------------------------------------------------------
// <copyright file="IClient.cs" company="">
//    Copyright (c) Tony Williams 2010. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace DOAP
{
  using System;
  using System.Collections.Generic;

  /// <summary>
  /// Defines the required fields for a client
  /// </summary>
  /// <typeparam name="TIdentityType">The type of the identity type.</typeparam>
  public interface IClient<TIdentityType>
  {
    /// <summary>
    /// Gets or sets the id.
    /// </summary>
    /// <value>The id.</value>
    TIdentityType Id { get; set; }

    /// <summary>
    /// Gets or sets the secret.
    /// </summary>
    /// <value>The secret.</value>
    string Secret { get; set; }

    /// <summary>
    /// Gets or sets the redirect URI.
    /// </summary>
    /// <value>The redirect URI.</value>
    IEnumerable<Uri> RedirectUri { get; set; }

    /// <summary>
    /// Gets or sets the allowed grant types.
    /// </summary>
    /// <value>The allowed grant types.</value>
    IEnumerable<GrantType> AllowedGrantTypes { get; set; }
  }
}
