using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using WcfRestContrib.ServiceModel.Description;
using WcfRestContrib.ServiceModel.Dispatcher;

namespace DOAP.WCF
{
  public class OperationOAuthAuthenticationBehavior : IOperationBehavior
  {
    public string Scope { get; set; }
    public bool AllowAnonymous { get; set; }
    // ────────────────────────── IOperationBehavior Members ──────────────────────────

    public void ApplyDispatchBehavior(OperationDescription operationDescription,
        DispatchOperation dispatchOperation)
    {
      var behavior =
          operationDescription.DeclaringContract.FindBehavior
              <OAuthAuthenticationConfigurationBehavior,
              OAuthAuthenticationConfigurationAttribute>(b => b.BaseBehavior);

      if (behavior == null)
        behavior = dispatchOperation.Parent.ChannelDispatcher.Host.Description.FindBehavior
                <OAuthAuthenticationConfigurationBehavior,
                OAuthAuthenticationConfigurationAttribute>(b => b.BaseBehavior);

      if (behavior == null)
        throw new ConfigurationErrorsException(
            "OperationAuthenticationConfigurationBehavior not applied to contract or service. This behavior is required to configure operation authentication.");

      var scopeToUse = string.IsNullOrWhiteSpace(this.Scope) ? behavior.Scope : this.Scope;

      dispatchOperation.Invoker = new OperationOAuthAuthenticationInvoker(
          dispatchOperation.Invoker,
          behavior.AuthenticationHandler,
          behavior.RequireSecureTransport,
           scopeToUse, 
           AllowAnonymous;
    }

    public void ApplyClientBehavior(OperationDescription operationDescription,
        ClientOperation clientOperation) { }
    public void AddBindingParameters(OperationDescription operationDescription,
        BindingParameterCollection bindingParameters) { }
    public void Validate(OperationDescription operationDescription) { }
  }
}
