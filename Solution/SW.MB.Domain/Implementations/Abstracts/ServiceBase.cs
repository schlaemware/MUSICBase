using System.Reflection;
using SW.MB.Data.Models.Entities.Abstracts;

namespace SW.MB.Domain.Implementations.Abstracts {
  internal abstract class ServiceBase {
    private static IServiceProvider? _ServiceProvider;

    protected IServiceProvider ServiceProvider => _ServiceProvider
      ?? throw new ApplicationException($"{nameof(_ServiceProvider)} not instantiated!");

    #region CONSTRUCTORS
    public ServiceBase(IServiceProvider serviceProvider) {
      _ServiceProvider ??= serviceProvider;
    }
    #endregion CONSTRUCTORS

    protected static void SetAllProperties(Entity? origin, Entity? fromRecord) {
      if (origin != null && fromRecord != null && origin.GetType() == fromRecord.GetType()) {
        foreach (PropertyInfo property in origin.GetType().GetProperties().Where(x => x.CanRead && x.CanWrite)) {
          property.SetValue(origin, property.GetValue(fromRecord));
        }
      }
    }
  }
}
