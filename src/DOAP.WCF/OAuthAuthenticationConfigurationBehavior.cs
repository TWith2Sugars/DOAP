using System;
using System.ServiceModel.Description;
using DOAP.WCF;
using WcfRestContrib.ServiceModel.Dispatcher;
using System.IdentityModel.Selectors;

namespace WcfRestContrib.ServiceModel.Description
{
    public class OAuthAuthenticationConfigurationBehavior : IServiceBehavior, IContractBehavior 
    {
        // ────────────────────────── Constructors ──────────────────────────

      public OAuthAuthenticationConfigurationBehavior(
            Type authenticationHandler,
            bool requireSecureTransport,
            string scope)
        {
            AuthenticationHandler = 
                (IOAuthAuthenticationHandler)Activator.CreateInstance(authenticationHandler);
            Scope = scope;
            RequireSecureTransport = requireSecureTransport;
        }

        // ────────────────────────── Public Members ──────────────────────────

      public IOAuthAuthenticationHandler AuthenticationHandler { get; set; }
        public bool RequireSecureTransport { get; set; }
        public string Scope { get; set; }

        // ────────────────────────── IServiceBehavior Members ──────────────────────────

        public void AddBindingParameters(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase, System.Collections.ObjectModel.Collection<ServiceEndpoint> endpoints, System.ServiceModel.Channels.BindingParameterCollection bindingParameters) { }
        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase) { }
        public void Validate(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase) { }

        // ────────────────────────── IContractBehavior Members ──────────────────────────

        public void AddBindingParameters(ContractDescription contractDescription, ServiceEndpoint endpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters) { }
        public void ApplyClientBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.ClientRuntime clientRuntime) { }
        public void ApplyDispatchBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.DispatchRuntime dispatchRuntime) { }
        public void Validate(ContractDescription contractDescription, ServiceEndpoint endpoint) { }
}
}
