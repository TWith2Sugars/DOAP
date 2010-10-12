//-----------------------------------------------------------------------
// <copyright file="Response.cs" company="">
//     Copyright (c) Tony Williams 2010. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace DOAP.Response
{
  using System;
  using System.Net;

  /// <summary>
  /// The base response class
  /// </summary>
  public class Response
  {
    /// <summary>
    /// Gets or sets the error code.
    /// </summary>
    /// <value>The error code.</value>
    public ErrorCode ErrorCode { get; set; }

    /// <summary>
    /// Gets the Http Status code based on the OAuth error
    /// </summary>
    /// <returns>A http status code
    /// </returns>
    public HttpStatusCode StatusCode()
    {
      switch (this.ErrorCode)
      {
        case ErrorCode.None:
          return HttpStatusCode.OK;
        case ErrorCode.InvalidToken:
        case ErrorCode.ExpiredToken:
        case ErrorCode.InvalidClient:
        case ErrorCode.InsufficientScope:
        case ErrorCode.AccessDenied:
        case ErrorCode.UnAuthorizedClient:
          return HttpStatusCode.Unauthorized;

        default:
          return HttpStatusCode.BadRequest;
      }
    }

    /// <summary>
    /// Returns the OAuth error from the 
    /// </summary>
    /// <returns>The OAuth error</returns>
    public string Error()
    {
      switch (this.ErrorCode)
      {
        case ErrorCode.AccessDenied:
          return "access_denied";
        case ErrorCode.ExpiredToken:
          return "expired_token";
        case ErrorCode.InsufficientScope:
          return "insufficient_scope";
        case ErrorCode.InvalidClient:
          return "invalid_client";
        case ErrorCode.InvalidGrant:
          return "invalid_grant";
        case ErrorCode.InvalidRequest:
          return "invalid_request";
        case ErrorCode.InvalidScope:
          return "invalid_scope";
        case ErrorCode.InvalidToken:
          return "invalid_token";
        case ErrorCode.RedirectUriMismatch:
          return "redirect_uri_mismatch";
        case ErrorCode.UnAuthorizedClient:
          return "unauthorized_client";
        case ErrorCode.UnSupportedGrantType:
          return "unsupported_grant_type";
        case ErrorCode.UnSupportedResponseType:
          return "unsupported_response_type";
        default:
          throw new ArgumentOutOfRangeException();
      }
    }
  }
}
