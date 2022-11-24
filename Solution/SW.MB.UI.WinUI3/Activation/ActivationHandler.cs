﻿using System.Threading.Tasks;
using SW.MB.UI.WinUI3.Contracts.Activation;

namespace SW.MB.UI.WinUI3.Activation {
  public abstract class ActivationHandler<T> : IActivationHandler where T : class {
    // Override this method to add the logic for whether to handle the activation.
    protected virtual bool CanHandleInternal(T args) => true;

    // Override this method to add the logic for your activation handler.
    protected abstract Task HandleInternalAsync(T args);

    public bool CanHandle(object args) => args is T && CanHandleInternal((args as T)!);

    public async Task HandleAsync(object args) => await HandleInternalAsync((args as T)!);
  }
}
