using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DOAP.Provider;

namespace DOAP.WCFExample.Provider
{
  public class PasswordProvider:IPasswordProvider<int>
  {
    /// <summary>
    /// Checks the resource owner credentials.
    /// </summary>
    /// <param name="username">The username.</param>
    /// <param name="password">The password.</param>
    /// <returns>The resource owner</returns>
    public int CheckResourceOwnerCredentials(string username, string password)
    {
      // This would generally hit your DB or something similar
      if(username == "admin" && password == "password")
      {
        // This would be the id of the resource owner (the user). 
        return 1;
      }

      // Since we cant find the user return the 0. Wish I could make this nullable
      return 0;
    }
  }
}