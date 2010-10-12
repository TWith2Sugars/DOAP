//-----------------------------------------------------------------------
// <copyright file="VerificationResponse.cs" company="">
//    Copyright (c) Tony Williams 2010. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace DOAP.Response
{
  /// <summary>
  /// The response given when verifying an access token
  /// </summary>
  /// <typeparam name="TResourceOwnerIdentity">The type of the resource owner identity.</typeparam>
  public class VerificationResponse<TResourceOwnerIdentity> : Response
  {
    /// <summary>
    /// Gets or sets the resource owner id.
    /// </summary>
    /// <value>The resource owner id.</value>
    public TResourceOwnerIdentity ResourceOwnerId { get; set; }
  }
}
