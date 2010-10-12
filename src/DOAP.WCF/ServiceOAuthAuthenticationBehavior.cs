using System;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Description;
using System.ServiceModel.Channels;
using WcfRestContrib.ServiceModel.Description;
using WcfRestContrib.ServiceModel.Dispatcher;

namespace DOAP.WCF
{
    public class ServiceOAuthAuthenticationBehavior : IServiceBehavior, IContractBehavior 
    {
      public string Scope { get; set; }

        // ────────────────────────── Private Members ──────────────────────────

        public class ServiceAuthenticationConfigurationMissingException : Exception
        {
            public ServiceAuthenticationConfigurationMissingException() : 
                base("ServiceAuthenticationConfigurationBehavior not applied to contract or service. This behavior is required to configure service authentication.") {}
        }

        // ────────────────────────── IServiceBehavior Members ──────────────────────────

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase)
        {
            var behavior = 
                serviceHostBase.Description.FindBehavior
                        <OAuthAuthenticationConfigurationBehavior,
                        OAuthAuthenticationConfigurationAttribute>(b => b.BaseBehavior);

            if (behavior == null)
                throw new ServiceAuthenticationConfigurationMissingException();
            var scopeToUse = string.IsNullOrWhiteSpace(this.Scope) ? behavior.Scope : this.Scope;
            foreach (ChannelDispatcher dispatcher in 
                serviceHostBase.ChannelDispatchers)
                foreach (var endpoint in dispatcher.Endpoints)
                    endpoint.DispatchRuntime.MessageInspectors.Add(
                        new ServiceOAuthAuthenticationInspector(
                            behavior.AuthenticationHandler,
                            behavior.RequireSecureTransport,
                            scopeToUse));
        }

        public void Validate(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase) { }
        public void AddBindingParameters(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase, System.Collections.ObjectModel.Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters) { }

        // ────────────────────────── IContractBehavior Members ──────────────────────────

        public void ApplyDispatchBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, DispatchRuntime dispatchRuntime)
        {
            var behavior = 
                dispatchRuntime.ChannelDispatcher.Host.Description.FindBehavior
                        <OAuthAuthenticationConfigurationBehavior,
                        OAuthAuthenticationConfigurationAttribute>(b => b.BaseBehavior);
            
            if (behavior == null)
                behavior = contractDescription.FindBehavior
                        <OAuthAuthenticationConfigurationBehavior,
                        OAuthAuthenticationConfigurationAttribute>(b => b.BaseBehavior);

            if (behavior == null)
                throw new ServiceAuthenticationConfigurationMissingException();
            var scopeToUse = string.IsNullOrWhiteSpace(this.Scope) ? behavior.Scope : this.Scope;
            foreach (var endpointDispatcher in dispatchRuntime.ChannelDispatcher.Endpoints)
                endpointDispatcher.DispatchRuntime.MessageInspectors.Add(
                    new ServiceOAuthAuthenticationInspector(
                        behavior.AuthenticationHandler,
                        behavior.RequireSecureTransport,
                        scopeToUse));
        }

        public void Validate(ContractDescription contractDescription, ServiceEndpoint endpoint) { }
        public void AddBindingParameters(ContractDescription contractDescription, ServiceEndpoint endpoint, BindingParameterCollection bindingParameters) { }
        public void ApplyClientBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, ClientRuntime clientRuntime) { }
    }
}
