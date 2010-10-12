using System;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Web;
using System.ServiceModel.Channels;
using System.IdentityModel.Selectors;
using System.ServiceModel;
using DOAP.WCF;
using WcfRestContrib.ServiceModel;

namespace DOAP.WCF
{
    public class ServiceOAuthAuthenticationInspector : Attribute, IDispatchMessageInspector 
    {
        // ────────────────────────── Private Fields ──────────────────────────

        private readonly IOAuthAuthenticationHandler _handler;
        private readonly bool _requiresTransportLayerSecurity;
        private readonly string _scope;

        // ────────────────────────── Constructors ──────────────────────────

        public ServiceOAuthAuthenticationInspector(
            IOAuthAuthenticationHandler handler,
            bool requiresTransportLayerSecurity,
            string scope)
        {
            _handler = handler;
            _requiresTransportLayerSecurity = requiresTransportLayerSecurity;
            _scope = scope;
        }

        // ────────────────────────── IDispatchMessageInspector Members ──────────────────────────

        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            OperationContext.Current.ReplacePrimaryIdentity(_handler.Authenticate(
                WebOperationContext.Current.IncomingRequest,
                WebOperationContext.Current.OutgoingResponse,
                new object[] {},
                OperationContext.Current.HasTransportLayerSecurity(),
                _requiresTransportLayerSecurity,
                _scope));

            return null;
        }

        public void BeforeSendReply(ref Message reply, object correlationState) { }
    }
}
