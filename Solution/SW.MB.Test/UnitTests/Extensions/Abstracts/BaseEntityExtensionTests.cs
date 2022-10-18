using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SW.MB.Test.UnitTests.Extensions.Abstracts {
    public abstract class BaseEntityExtensionTests {
        protected static readonly Random Random = new();

        protected void CompareValues<TRecord, TEntity>(TRecord record, TEntity entity) {
            Assert.IsNotNull(record);
            Assert.IsNotNull(entity);

            foreach (PropertyInfo propertyInfo in record.GetType().GetProperties()) {
                object? value = propertyInfo.GetValue(record);
                object? reference = entity.GetType().GetProperty(propertyInfo.Name)?.GetValue(entity);

                Assert.IsNotNull(value);
                Assert.IsNotNull(reference);
                Assert.AreEqual(value, reference);
            }
        }
    }
}
