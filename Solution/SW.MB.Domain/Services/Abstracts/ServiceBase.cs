namespace SW.MB.Domain.Services.Abstracts {
    internal abstract class ServiceBase {
        protected Serilog.ILogger Logger => Serilog.Log.Logger;
    }
}
