using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DOAP.Provider;

namespace DOAP.WCFExample.Provider
{
  public class ClientProvider: IClientProvider<int>
  {
    private readonly Client someClient = new Client
                                  {
                                    Id = 1,
                                    Secret = "secret",
                                    AllowedGrantTypes = new List<GrantType>
                                                          {
                                                            GrantType.None,
                                                            GrantType.RefreshToken,
                                                            GrantType.Password
                                                          }
                                  };

    /// <summary>
    /// Finds the client by id.
    /// </summary>
    /// <param name="clientId">The client id.</param>
    /// <returns>The client</returns>
    public IClient<int> FindClientById(int clientId)
    {
      if(clientId == this.someClient.Id)
      {
        return this.someClient;
      }

      return null;
    }
  }
}