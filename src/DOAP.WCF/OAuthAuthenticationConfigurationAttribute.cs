using System;
using System.ServiceModel.Description;
using System.ServiceModel.Channels;
using WcfRestContrib.ServiceModel.Description;
using WcfRestContrib.ServiceModel.Dispatcher;
using System.IdentityModel.Selectors;
using WcfRestContrib.Reflection;

namespace DOAP.WCF
{
    public class OAuthAuthenticationConfigurationAttribute : Attribute, IServiceBehavior 
    {
        // ────────────────────────── Private Fields ───────────────────────────

      readonly OAuthAuthenticationConfigurationBehavior _behavior;

        // ────────────────────────── Constructors ─────────────────────────────

        public OAuthAuthenticationConfigurationAttribute(
            Type authenticationHandler,
            bool requireSecureTransport,
            string scope)
        {
            if (!authenticationHandler.CastableAs<IOAuthAuthenticationHandler>())
                throw new Exception(string.Format("authenticationHandler {0} must implement IWebAuthenticationHandler.", authenticationHandler.Name));


            _behavior = new OAuthAuthenticationConfigurationBehavior(
                authenticationHandler,
                
                requireSecureTransport,
                scope);
        }

        // ────────────────────────── Public Members ─────────────────────────────

        public OAuthAuthenticationConfigurationBehavior BaseBehavior
        { get { return _behavior; } }

        // ────────────────────────── IServiceBehavior Members ───────────────────

        public void AddBindingParameters(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase, System.Collections.ObjectModel.Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        { _behavior.AddBindingParameters(serviceDescription, serviceHostBase, endpoints, bindingParameters); }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase)
        { _behavior.ApplyDispatchBehavior(serviceDescription, serviceHostBase); }

        public void Validate(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase)
        { _behavior.Validate(serviceDescription, serviceHostBase); }
    }
}
