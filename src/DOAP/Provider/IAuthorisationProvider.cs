//-----------------------------------------------------------------------
// <copyright file="IAuthorisationProvider.cs" company="">
//    Copyright (c) Tony Williams 2010. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace DOAP.Provider
{
  /// <summary>
  /// Defines the methods for an Authorisation provider
  /// </summary>
  /// <typeparam name="TClientIdentity">The type of the client identity.</typeparam>
  /// <typeparam name="TResourceOwnerIdentity">The type of the resource owner identity.</typeparam>
  public interface IAuthorisationProvider<TClientIdentity, TResourceOwnerIdentity>
  {
    /// <summary>
    /// Stores the authorise client.
    /// </summary>
    /// <param name="response">The response.</param>
    void StoreAuthoriseClient(AuthorisationCode<TClientIdentity, TResourceOwnerIdentity> response);

    /// <summary>
    /// Finds the authorisation code.
    /// </summary>
    /// <param name="authorisationCode">The authorisation code.</param>
    /// <returns>The authorisation code</returns>
    AuthorisationCode<TClientIdentity, TResourceOwnerIdentity> FindAuthorisationCode(string authorisationCode);
  }
}
