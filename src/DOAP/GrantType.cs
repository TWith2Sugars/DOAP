//-----------------------------------------------------------------------
// <copyright file="GrantType.cs" company="">
//    Copyright (c) Tony Williams 2010. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace DOAP
{
  /// <summary>
  /// The various grant types 
  /// </summary>
  public enum GrantType
  {
    /// <summary>
    /// As defined: http://tools.ietf.org/html/draft-ietf-oauth-v2-10#section-4.1.1
    /// </summary>
    AuthorizationCode,

    /// <summary>
    /// As defined: http://tools.ietf.org/html/draft-ietf-oauth-v2-10#section-4.1.2
    /// </summary>
    Password,

    /// <summary>
    /// As defined: http://tools.ietf.org/html/draft-ietf-oauth-v2-10#section-4.1.3
    /// </summary>
    Assertion,

    /// <summary>
    /// As defined: http://tools.ietf.org/html/draft-ietf-oauth-v2-10#section-4.1.4
    /// </summary>
    RefreshToken,

    /// <summary>
    /// 2-legged auth (just the client and it's own/public resources)
    /// </summary>
    None,

    /// <summary>
    /// Unrecognised grant type
    /// </summary>
    Unknown
  }
}
