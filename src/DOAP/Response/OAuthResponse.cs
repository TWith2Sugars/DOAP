//-----------------------------------------------------------------------
// <copyright file="AccessTokenResponse.cs" company="">
//    Copyright (c) Tony Williams 2010. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace DOAP.Response
{
  using System.Runtime.Serialization;

  /// <summary>
  /// The response to an OAuth request
  /// </summary>
  /// <remarks>http://tools.ietf.org/html/draft-ietf-oauth-v2-10</remarks>
  [DataContract]
  public class OAuthResponse
  {
    /// <summary>
    /// Gets or sets the error.
    /// </summary>
    /// <value>The error.</value>
    [DataMember(Name = "error", EmitDefaultValue = false)]
    public string Error { get; set; }

    /// <summary>
    /// Gets or sets the access token.
    /// </summary>
    /// <value>The access token.</value>
    [DataMember(Name = "access_token", EmitDefaultValue = false)]
    public string AccessToken { get; set; }

    /// <summary>
    /// Gets or sets the expires in.
    /// </summary>
    /// <value>The expires in.</value>
    [DataMember(Name = "expires_in", EmitDefaultValue = false)]
    public int? ExpiresIn { get; set; }

    /// <summary>
    /// Gets or sets the refresh token.
    /// </summary>
    /// <value>The refresh token.</value>
    [DataMember(Name = "refresh_token", EmitDefaultValue = false)]
    public string RefreshToken { get; set; }
  }
}
