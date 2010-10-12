//-----------------------------------------------------------------------
// <copyright file="IClientProvider.cs" company="">
//     Copyright (c) Tony Williams 2010. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace DOAP.Provider
{
  /// <summary>
  /// Defines the methods for accessing a client
  /// </summary>
  /// <typeparam name="TClientIdentity">The type of the client identity.</typeparam>
  public interface IClientProvider<TClientIdentity>
  {
    /// <summary>
    /// Finds the client by id.
    /// </summary>
    /// <param name="clientId">The client id.</param>
    /// <returns>The client</returns>
    IClient<TClientIdentity> FindClientById(TClientIdentity clientId);
  }
}
