using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Web;
using DOAP.WCF;

namespace DOAP.WCFExample
{
  // Configures the OAuth handler for this service. the default scope is blank but we can easily change it to something else
  [OAuthAuthenticationConfiguration(typeof(OAuth.OAuthHandler),true,"")]
  [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
  [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
  [ServiceContract]
  public class SampleService
  {
    // We could create a base service class that has this property as well as some of the service attributes above.
    private bool IsAnonymous
    {
      get
      {
        if (ServiceSecurityContext.Current == null)
        {
          return true;
        }

        return ServiceSecurityContext.Current.PrimaryIdentity == null;
      }
    }

    [WebGet(UriTemplate = "Anon"), OperationContract]
    public string AnonymousCall()
    {
      return "This is an anonymous call";
    }

    // We could use the Operation OAuth attribute here OR the ServiceOAuthAuthentication attribute on the class
    [WebGet(UriTemplate = "Secure"), OperationContract, OperationOAuthAuthentication]
    public string SecureCall()
    {
      return "This is a secure call";
    }

    [WebGet(UriTemplate = "SemiSecure"), OperationContract, OperationOAuthAuthentication(allowAnonymous:true)]
    public string SemiSecureCall()
    {
      if(this.IsAnonymous)
      {
        return "This is a semi secure call that is anonymous";
      }

      return "This is a semi secure call that is secure";
    }
  }
}