using System.Reflection;
using SW.MB.Data.Models.Entities.Abstracts;

namespace SW.MB.Domain.Services.Abstracts {
    internal abstract class DataServiceBase : ServiceBase {
    protected static void SetAllProperties(Entity? origin, Entity? fromRecord) {
      if (origin != null && fromRecord != null && origin.GetType() == fromRecord.GetType()) {
        foreach (PropertyInfo property in origin.GetType().GetProperties().Where(x => x.CanRead && x.CanWrite)) {
          property.SetValue(origin, property.GetValue(fromRecord));
        }
      }
    }
  }
}
