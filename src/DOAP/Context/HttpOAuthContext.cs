//-----------------------------------------------------------------------
// <copyright file="HttpContext.cs" company="">
//    Copyright (c) Tony Williams 2010. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace DOAP.Context
{
  using System;
  using System.Web;
  using System.Collections.Generic;

  /// <summary>
  /// Adapts an http Context to the <see cref="ITokenContext{TClientTypeIdentity}"/> interface
  /// </summary>
  /// <typeparam name="TClientIdentity">The type of the client identity.</typeparam>
  public class HttpOAuthContext<TClientIdentity> : ITokenContext<TClientIdentity>, IAuthorisationContext<TClientIdentity>
  {
    #region OAuth Consts
    /// <summary>
    /// The OAuth assertion parameter name
    /// </summary>
    private const string AssertionParameter = "assertion";

    /// <summary>
    /// The OAuth assertion type parameter name
    /// </summary>
    private const string AssertionTypeParameter = "assertion_type";

    /// <summary>
    /// The OAuth client id parameter name
    /// </summary>
    private const string ClientIdParameter = "client_id";

    /// <summary>
    /// The OAuth client secret parameter name
    /// </summary>
    private const string ClientSecretParameter = "client_secret";

    /// <summary>
    /// The OAuth code parameter name
    /// </summary>
    private const string CodeParameter = "code";

    /// <summary>
    /// The OAuth grant parameter name
    /// </summary>
    private const string GrantParameter = "grant_type";

    /// <summary>
    /// The OAuth password parameter name
    /// </summary>
    private const string PasswordParameter = "password";

    /// <summary>
    /// The OAuth redirect URI parameter name
    /// </summary>
    private const string RedirectUriParameter = "redirect_uri";

    /// <summary>
    /// The OAuth refresh token parameter name
    /// </summary>
    private const string RefreshTokenParameter = "refresh_token";

    /// <summary>
    /// The OAuth response type parameter name
    /// </summary>
    private const string ResponseTypeParameter = "response_type";

    /// <summary>
    /// The OAuth scope parameter name
    /// </summary>
    private const string ScopeParameter = "scope";

    /// <summary>
    /// The OAuth state parameter name
    /// </summary>
    private const string StateParameter = "state";

    /// <summary>
    /// The OAuth username parameter name
    /// </summary>
    private const string UsernameParameter = "username";

    /// <summary>
    /// The OAuth grant_type parameter Authorisation code value
    /// </summary>
    private const string GrantTypeAuthorisationCode = "authorization_code";

    /// <summary>
    /// The OAuth grant_type parameter assertion value
    /// </summary>
    private const string GrantTypeAssertion = "assertion";

    /// <summary>
    /// The OAuth grant_type parameter none value
    /// </summary>
    private const string GrantTypeNone = "none";

    /// <summary>
    /// The OAuth grant_type parameter password value
    /// </summary>
    private const string GrantTypePassword = "password";

    /// <summary>
    /// The OAuth grant_type parameter refresh token value
    /// </summary>
    private const string GrantTypeRefreshToken = "refresh_token";

    /// <summary>
    /// The OAuth response_type parameter token value
    /// </summary>
    private const string ResponseTypeToken= "token";

    /// <summary>
    /// The OAuth response_type parameter code value
    /// </summary>
    private const string ResponseTypeCode = "code";

    /// <summary>
    /// The OAuth response_type parameter code and token value
    /// </summary>
    private const string ResponseTypeCodeAndToken = "code_and_token";
    #endregion

    /// <summary>
    /// The grant type of this request
    /// </summary>
    private GrantType? grantType;

    /// <summary>
    /// The response type
    /// </summary>
    private ResponseType? responseType;

    /// <summary>
    /// The http context
    /// </summary>
    private readonly HttpContext httpContext;

    /// <summary>
    /// The scopes the caller requests
    /// </summary>
    private List<string> requestedScope;

    /// <summary>
    /// HTTPs the context.
    /// </summary>
    /// <param name="httpContext">The HTTP tokenContext.</param>
    public HttpOAuthContext(HttpContext httpContext)
    {
      this.httpContext = httpContext;
    }

    /// <summary>
    /// Gets the assertion.
    /// </summary>
    /// <value>The assertion.</value>
    public string Assertion
    {
      get
      {
        return this.AccessParameter(AssertionParameter);
      }
    }

    /// <summary>
    /// Gets the type of the assertion.
    /// </summary>
    /// <value>The type of the assertion.</value>
    public string AssertionType
    {
      get
      {
        return this.AccessParameter(AssertionTypeParameter);
      }
    }

    /// <summary>
    /// Gets the type of the grant.
    /// </summary>
    /// <value>The type of the grant.</value>
    public GrantType GrantType
    {
      get
      {
        if (!this.grantType.HasValue)
        {
          var requestedGrantType = this.AccessParameter(GrantParameter);
          switch (requestedGrantType)
          {
            case GrantTypeAuthorisationCode:
              this.grantType = GrantType.AuthorizationCode;
              break;
            case GrantTypeAssertion:
              this.grantType = GrantType.Assertion;
              break;
            case GrantTypeNone:
              this.grantType = GrantType.None;
              break;
            case GrantTypePassword:
              this.grantType = GrantType.Password;
              break;
            case GrantTypeRefreshToken:
              this.grantType = GrantType.RefreshToken;
              break;
            default:
              this.grantType = GrantType.Unknown;
              break;
          }
        }

        return this.grantType.Value;
      }
    }

    /// <summary>
    /// Gets the code.
    /// </summary>
    /// <value>The code.</value>
    public string Code
    {
      get
      {
        return this.AccessParameter(CodeParameter);
      }
    }

    /// <summary>
    /// Gets the state.
    /// </summary>
    /// <value>The state.</value>
    public string State
    {
      get
      {
        return this.AccessParameter(StateParameter);
      }
    }

    /// <summary>
    /// Gets the type of the response.
    /// </summary>
    /// <value>The type of the response.</value>
    public ResponseType ResponseType
    {
      get
      {
        if (!this.responseType.HasValue)
        {
          var requestedGrantType = this.AccessParameter(ResponseTypeParameter);
          switch (requestedGrantType)
          {
            case ResponseTypeCode:
              this.responseType = ResponseType.Code;
              break;
            case ResponseTypeCodeAndToken:
              this.responseType = ResponseType.CodeAndToken;
              break;
            case ResponseTypeToken:
              this.responseType = ResponseType.Token;
              break;
            default:
              this.responseType = ResponseType.Unknown;
              break;
          }
        }

        return this.responseType.Value;
      }
    }

    /// <summary>
    /// Gets the redirect URI.
    /// </summary>
    /// <value>The redirect URI.</value>
    public Uri RedirectUri
    {
      get
      {
        var requestUri = this.AccessParameter(RedirectUriParameter);
        Uri potentialUri;
        if (Uri.TryCreate(requestUri, UriKind.Absolute, out potentialUri))
        {
          return potentialUri;
        }

        return null;
      }
    }

    /// <summary>
    /// Gets the client id.
    /// </summary>
    /// <value>The client id.</value>
    public TClientIdentity ClientId
    {
      get
      {
        var requestClientId = this.AccessParameter(ClientIdParameter);
        return (TClientIdentity)Convert.ChangeType(requestClientId, typeof(TClientIdentity));
      }
    }

    /// <summary>
    /// Gets the client secret.
    /// </summary>
    /// <value>The client secret.</value>
    public string ClientSecret
    {
      get
      {
        return this.AccessParameter(ClientSecretParameter);
      }
    }

    /// <summary>
    /// Gets the scope.
    /// </summary>
    /// <value>The scope.</value>
    public IEnumerable<string> Scope
    {
      get
      {
        if (this.requestedScope == null)
        {
          this.requestedScope = new List<string>();
          var scopes = this.AccessParameter(ScopeParameter) ?? string.Empty;
          foreach(var scope in scopes.Split(' '))
          {
            this.requestedScope.Add(scope.Trim());
          }
        }

        return this.requestedScope;
      }
    }

    /// <summary>
    /// Gets the username.
    /// </summary>
    /// <value>The username.</value>
    public string Username
    {
      get
      {
        return this.AccessParameter(UsernameParameter);
      }
    }

    /// <summary>
    /// Gets the password.
    /// </summary>
    /// <value>The password.</value>
    public string Password
    {
      get
      {
        return this.AccessParameter(PasswordParameter);
      }
    }

    /// <summary>
    /// Gets the refresh token.
    /// </summary>
    /// <value>The refresh token.</value>
    public string RefreshToken
    {
      get
      {
        return this.AccessParameter(RefreshTokenParameter);
      }
    }

    /// <summary>
    /// Accesses the parameter.
    /// </summary>
    /// <param name="parameter">The parameter.</param>
    /// <returns>The value in the parameter field</returns>
    private string AccessParameter(string parameter)
    {
      return this.httpContext.Request[parameter];
    }
  }
}
