//-----------------------------------------------------------------------
// <copyright file="IPasswordProvider.cs" company="">
//    Copyright (c) Tony Williams 2010. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace DOAP.Provider
{
  /// <summary>
  /// Defines the necessary methods for accessing a resource owner, only used against the PASSWORD grant
  /// </summary>
  /// <typeparam name="TResourceOwnerIdentity">The type of the resource owner identity.</typeparam>
  public interface IPasswordProvider<out TResourceOwnerIdentity>
  {
    /// <summary>
    /// Checks the resource owner credentials.
    /// </summary>
    /// <param name="username">The username.</param>
    /// <param name="password">The password.</param>
    /// <returns>The resource owner</returns>
    TResourceOwnerIdentity CheckResourceOwnerCredentials(string username, string password);
  }
}
