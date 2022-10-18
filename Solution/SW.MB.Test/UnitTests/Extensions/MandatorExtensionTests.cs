using Microsoft.VisualStudio.TestTools.UnitTesting;
using SW.Framework.Extensions;
using SW.MB.Data.Models.Entities;
using SW.MB.Domain.Extensions;
using SW.MB.Domain.Models.Records;
using SW.MB.Test.UnitTests.Extensions.Abstracts;

namespace SW.MB.Test.UnitTests.Extensions {
    [TestClass]
    public class MandatorExtensionTests : BaseEntityExtensionTests {
        [TestMethod]
        public void ToRecord() {
            MandatorEntity entity = CreateEntity();

            MandatorRecord record = entity.ToRecord();

            CompareValues(record, entity);
        }

        [TestMethod]
        public void ToEntity() {
            MandatorRecord record = CreateRecord();

            MandatorEntity entity = record.ToEntity();

            CompareValues(record, entity);
        }

        protected static MandatorEntity CreateEntity() {
            return new MandatorEntity() {
                ID = Random.Next(),
                Created = DateTime.Now,
                CreatedBy = Random.Next(),
                Updated = DateTime.Now,
                UpdatedBy = Random.Next(),
                Name = Random.NextTitle(),
            };
        }

        protected static MandatorRecord CreateRecord() {
            return new MandatorRecord() {
                ID = Random.Next(),
                Created = DateTime.Now,
                CreatedBy = Random.Next(),
                Updated = DateTime.Now,
                UpdatedBy = Random.Next(),
                Name = Random.NextTitle(),
            };
        }
    }
}
