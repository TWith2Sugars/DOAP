//-----------------------------------------------------------------------
// <copyright file="ITokenContext.cs" company="">
//    Copyright (c) Tony Williams 2010. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace DOAP.Context
{
  /// <summary>
  /// Defines the context required for getting an access token
  /// </summary>
  /// <typeparam name="TClientIdentity">The type of the client identity.</typeparam>
  public interface ITokenContext<out TClientIdentity> : IContext<TClientIdentity>
  {
    /// <summary>
    /// Gets the assertion.
    /// </summary>
    /// <value>The assertion.</value>
    string Assertion { get; }

    /// <summary>
    /// Gets the type of the assertion.
    /// </summary>
    /// <value>The type of the assertion.</value>
    string AssertionType { get; }

    /// <summary>
    /// Gets the type of the grant.
    /// </summary>
    /// <value>The type of the grant.</value>
    GrantType GrantType { get; }

    /// <summary>
    /// Gets the code.
    /// </summary>
    /// <value>The code.</value>
    string Code { get; }

    /// <summary>
    /// Gets the client secret.
    /// </summary>
    /// <value>The client secret.</value>
    string ClientSecret { get; }

    /// <summary>
    /// Gets the username.
    /// </summary>
    /// <value>The username.</value>
    string Username { get; }

    /// <summary>
    /// Gets the password.
    /// </summary>
    /// <value>The password.</value>
    string Password { get; }

    /// <summary>
    /// Gets the refresh token.
    /// </summary>
    /// <value>The refresh token.</value>
    string RefreshToken { get; }
  }
}
