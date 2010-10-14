using System;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Description;
using System.ServiceModel.Channels;

namespace DOAP.WCF
{
    public class ServiceOAuthAuthenticationAttribute : Attribute, IServiceBehavior, IContractBehavior
    {

          public ServiceOAuthAuthenticationAttribute(string scope = "", bool allowAnonymous = false)
          {
            this._behavior = new ServiceOAuthAuthenticationBehavior();
            this._behavior.Scope = scope;
            this._behavior.AllowAnonymous = allowAnonymous;
          }

      // ────────────────────────── Private Fields ──────────────────────────

      private readonly ServiceOAuthAuthenticationBehavior _behavior;

        // ────────────────────────── IServiceBehavior Members ──────────────────────────

        public void AddBindingParameters(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase, System.Collections.ObjectModel.Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        { _behavior.AddBindingParameters(serviceDescription, serviceHostBase, endpoints, bindingParameters); }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase)
        { _behavior.ApplyDispatchBehavior(serviceDescription, serviceHostBase); }

        public void Validate(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase)
        { _behavior.Validate(serviceDescription, serviceHostBase); }

        // ────────────────────────── IContractBehavior Members ──────────────────────────

        public void AddBindingParameters(ContractDescription contractDescription, ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        { _behavior.AddBindingParameters(contractDescription, endpoint, bindingParameters); }

        public void ApplyClientBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        { _behavior.ApplyClientBehavior(contractDescription, endpoint, clientRuntime); }

        public void ApplyDispatchBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, DispatchRuntime dispatchRuntime)
        { _behavior.ApplyDispatchBehavior(contractDescription, endpoint, dispatchRuntime); }

        public void Validate(ContractDescription contractDescription, ServiceEndpoint endpoint)
        { _behavior.Validate(contractDescription, endpoint); }
    }
}
