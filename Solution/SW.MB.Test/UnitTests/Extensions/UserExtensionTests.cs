using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SW.Framework.Extensions;
using SW.MB.Data.Models.Entities;
using SW.MB.Domain.Extensions;
using SW.MB.Domain.Models.Records;
using SW.MB.Test.UnitTests.Extensions.Abstracts;

namespace SW.MB.Test.UnitTests.Extensions {
    [TestClass]
    public class UserExtensionTests : BaseEntityExtensionTests {
        [TestMethod]
        public void ToRecord() {
            UserEntity entity = CreateEntity();

            UserRecord record = entity.ToRecord();

            CompareValues(record, entity);
        }

        [TestMethod]
        public void ToEntity() {
            UserRecord record = CreateRecord();

            UserEntity entity = record.ToEntity();

            CompareValues(record, entity);
        }

        protected static UserEntity CreateEntity() {
            return new UserEntity() {
                ID = Random.Next(),
                Created = DateTime.Now,
                CreatedBy = Random.Next(),
                Updated = DateTime.Now,
                UpdatedBy = Random.Next(),
                Firstname = Random.NextFirstname(),
                Lastname = Random.NextLastname(),
                DateOfBirth = Random.NextDateTimePast(),
                Mail = Random.NextString(),
            };
        }

        protected static UserRecord CreateRecord() {
            return new UserRecord() {
                ID = Random.Next(),
                Created = DateTime.Now,
                CreatedBy = Random.Next(),
                Updated = DateTime.Now,
                UpdatedBy = Random.Next(),
                Firstname = Random.NextFirstname(),
                Lastname = Random.NextLastname(),
                DateOfBirth = DateOnly.FromDateTime(Random.NextDateTimePast()),
                Mail = Random.NextString(),
            };
        }

        private static void CompareValues(UserRecord record, UserEntity entity) {
            Assert.IsNotNull(record);
            Assert.IsNotNull(entity);

            foreach (PropertyInfo propertyInfo in record.GetType().GetProperties()) {
                object? value = propertyInfo.GetValue(record);
                object? reference = entity.GetType().GetProperty(propertyInfo.Name)?.GetValue(entity);

                Assert.IsNotNull(value, "Value is null!");
                Assert.IsNotNull(reference, "Reference is null!");

                if (propertyInfo.PropertyType == typeof(DateOnly?) && value is DateOnly dateOnly && reference is DateTime dateTime) {
                    Assert.IsTrue(dateOnly.Year == dateTime.Year && dateOnly.Month == dateTime.Month && dateOnly.Day == dateTime.Day);
                } else {
                    Assert.AreEqual(value, reference);
                }
            }
        }
    }
}
