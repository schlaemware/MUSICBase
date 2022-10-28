using Microsoft.VisualStudio.TestTools.UnitTesting;
using SW.Framework.Extensions;
using SW.MB.Data.Models.Entities;
using SW.MB.Domain.Extensions;
using SW.MB.Domain.Extensions.EntityExtensions;
using SW.MB.Domain.Extensions.RecordExtensions;
using SW.MB.Domain.Models.Records;
using SW.MB.Test.UnitTests.Extensions.Abstracts;

namespace SW.MB.Test.UnitTests.Extensions
{
    [TestClass]
    public class CompositionExtensionTests : BaseEntityExtensionTests {
        [TestMethod]
        public void ToRecord() {
            CompositionEntity entity = CreateEntity();

            CompositionRecord record = entity.ToRecord();

            CompareValues(record, entity);
        }

        [TestMethod]
        public void ToEntity() {
            CompositionRecord record = CreateRecord();

            CompositionEntity entity = record.ToEntity();

            CompareValues(record, entity);
        }

        protected static CompositionEntity CreateEntity() {
            return new CompositionEntity() {
                ID = Random.Next(),
                Created = DateTime.Now,
                CreatedBy = Random.Next(),
                Updated = DateTime.Now,
                UpdatedBy = Random.Next(),
                Title = Random.NextTitle(),
            };
        }

        protected static CompositionRecord CreateRecord() {
            return new CompositionRecord() {
                ID = Random.Next(),
                Created = DateTime.Now,
                CreatedBy = Random.Next(),
                Updated = DateTime.Now,
                UpdatedBy = Random.Next(),
                Title = Random.NextTitle(),
            };
        }
    }
}
