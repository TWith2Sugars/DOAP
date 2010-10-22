using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DOAP.WCFExample
{
  public class Client: IClient<int>
  {
    public Client()
    {
      this.RedirectUri = new List<Uri>();
    }

    /// <summary>
    /// Gets or sets the id.
    /// </summary>
    /// <value>The id.</value>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the secret.
    /// </summary>
    /// <value>The secret.</value>
    public string Secret { get; set; }

    /// <summary>
    /// Gets or sets the redirect URI.
    /// </summary>
    /// <value>The redirect URI.</value>
    public IEnumerable<Uri> RedirectUri { get; set; }

    /// <summary>
    /// Gets or sets the allowed grant types.
    /// </summary>
    /// <value>The allowed grant types.</value>
    public IEnumerable<GrantType> AllowedGrantTypes { get; set; }
  }
}