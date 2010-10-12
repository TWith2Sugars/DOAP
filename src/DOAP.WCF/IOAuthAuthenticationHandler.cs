using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.ServiceModel.Web;
using System.Text;

namespace DOAP.WCF
{
  public interface IOAuthAuthenticationHandler
  {
    IIdentity Authenticate(
            IncomingWebRequestContext request,
            OutgoingWebResponseContext response,
            object[] parameters,
            bool secure,
            bool requiresTransportLayerSecurity,
            string scope);
  }
}
