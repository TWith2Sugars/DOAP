//-----------------------------------------------------------------------
// <copyright file="IAssertionProvider.cs" company="">
//     Copyright (c) Tony Williams 2010. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace DOAP.Provider
{
  /// <summary>
  /// Defines the methods for an assertion provider
  /// </summary>
  /// <typeparam name="TResourceOwnerIdentity">The type of the resource owner identity.</typeparam>
  public interface IAssertionProvider<out TResourceOwnerIdentity>
  {
    /// <summary>
    /// Validates the assertion.
    /// </summary>
    /// <param name="assertion">The assertion.</param>
    /// <param name="assertionType">Type of the assertion.</param>
    /// <returns>The resource owner id</returns>
    TResourceOwnerIdentity ValidateAssertion(string assertion, string assertionType);
  }
}
