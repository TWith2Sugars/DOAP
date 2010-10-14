using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Web;
using System.Text;
using WcfRestContrib.ServiceModel;

namespace DOAP.WCF
{
  public class OperationOAuthAuthenticationInvoker: Attribute, IOperationInvoker 
    {
   
        // ────────────────────────── Private Fields ──────────────────────────

        private readonly IOperationInvoker _invoker;
        private readonly IOAuthAuthenticationHandler _handler;
        private readonly bool _requiresTransportLayerSecurity;
        private readonly string _source;
        private readonly bool _allowAnonymous;

        // ────────────────────────── Constructors ──────────────────────────

        public OperationOAuthAuthenticationInvoker(
            IOperationInvoker invoker,
            IOAuthAuthenticationHandler handler,
            bool requiresTransportLayerSecurity,
            string source,
          bool allowAnonymous)
        {
            _invoker = invoker;
            _handler = handler;
            _requiresTransportLayerSecurity = requiresTransportLayerSecurity;
            _source = source;
          _allowAnonymous = allowAnonymous;
        }

        // ────────────────────────── IOperationInvoker Members ──────────────────────────

        public object[] AllocateInputs()
        { return _invoker.AllocateInputs(); }

        public object Invoke(object instance, object[] inputs, out object[] outputs)
        {
            OperationContext.Current.ReplacePrimaryIdentity(_handler.Authenticate(
                WebOperationContext.Current.IncomingRequest,
                WebOperationContext.Current.OutgoingResponse,
                inputs,
                OperationContext.Current.HasTransportLayerSecurity(),
                _requiresTransportLayerSecurity,
                _source,
                _allowAnonymous));

            return _invoker.Invoke(instance, inputs, out outputs);
        }

        public IAsyncResult InvokeBegin(object instance, object[] inputs, 
            AsyncCallback callback, object state)
        { throw new NotSupportedException(); }

        public object InvokeEnd(object instance, out object[] outputs, 
            IAsyncResult result)
        { throw new NotSupportedException(); }

        public bool IsSynchronous
        { get { return true; } }
    }

}
