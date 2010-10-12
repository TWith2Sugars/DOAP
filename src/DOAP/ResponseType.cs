//-----------------------------------------------------------------------
// <copyright file="ResponseType.cs" company="">
//    Copyright (c) Tony Williams 2010. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace DOAP
{
  /// <summary>
  /// The various response types
  /// </summary>
  public enum ResponseType
  {
    /// <summary>
    /// The response is just a token
    /// </summary>
    Token,

    /// <summary>
    /// The response is just a code
    /// </summary>
    Code,

    /// <summary>
    /// The response is both a token and code
    /// </summary>
    CodeAndToken,

    /// <summary>
    /// Who knows?
    /// </summary>
    Unknown
  }
}
