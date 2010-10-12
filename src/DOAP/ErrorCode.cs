//-----------------------------------------------------------------------
// <copyright file="ErrorCode.cs" company="">
//    Copyright (c) Tony Williams 2010. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace DOAP
{
  /// <summary>
  /// All errors as defined in: http://tools.ietf.org/html/draft-ietf-oauth-v2-10
  /// </summary>
  public enum ErrorCode
  {
    /// <summary>
    /// Used when no errors have occurred
    /// </summary>
    None,

    /// <summary>
    /// Access has been denied to a resource
    /// </summary>
    AccessDenied,

    /// <summary>
    /// Token provided is no longer valid
    /// </summary>
    ExpiredToken,

    /// <summary>
    /// Access required is out of scope
    /// </summary>
    InsufficientScope,

    /// <summary>
    /// Client does not exist
    /// </summary>
    InvalidClient,

    /// <summary>
    /// Invalid grant type
    /// </summary>
    InvalidGrant,

    /// <summary>
    /// Request it self is invalid
    /// </summary>
    InvalidRequest,

    /// <summary>
    /// Scope is not recognised
    /// </summary>
    InvalidScope,

    /// <summary>
    /// The token does not exist
    /// </summary>
    InvalidToken,

    /// <summary>
    /// The redirect URI provided does not match that on record
    /// </summary>
    RedirectUriMismatch,

    /// <summary>
    /// Client does not have access to the resource
    /// </summary>
    UnAuthorizedClient,

    /// <summary>
    /// Grant type is not supported by this server
    /// </summary>
    UnSupportedGrantType,

    /// <summary>
    /// Response type is unsupported by the server
    /// </summary>
    UnSupportedResponseType,
  }
}
