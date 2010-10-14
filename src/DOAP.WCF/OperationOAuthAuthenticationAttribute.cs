using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;

namespace DOAP.WCF
{
  public class OperationOAuthAuthenticationAttribute : Attribute, IOperationBehavior
  {

    public OperationOAuthAuthenticationAttribute(string scope = "", bool allowAnonymous = false)
    {
      this._behavior = new OperationOAuthAuthenticationBehavior();
      this._behavior.Scope = scope;
      this._behavior.AllowAnonymous = allowAnonymous;
    }

    // ────────────────────────── Private Fields ──────────────────────────

    readonly OperationOAuthAuthenticationBehavior _behavior = new OperationOAuthAuthenticationBehavior();

    // ────────────────────────── IOperationBehavior Members ──────────────────────────

    public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
    { _behavior.ApplyDispatchBehavior(operationDescription, dispatchOperation); }
    public void ApplyClientBehavior(OperationDescription operationDescription, ClientOperation clientOperation)
    { _behavior.ApplyClientBehavior(operationDescription, clientOperation); }
    public void AddBindingParameters(OperationDescription operationDescription, BindingParameterCollection bindingParameters)
    { _behavior.AddBindingParameters(operationDescription, bindingParameters); }
    public void Validate(OperationDescription operationDescription)
    { _behavior.Validate(operationDescription); }
  }
}
