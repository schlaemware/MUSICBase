using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SW.Framework.Extensions;
using SW.MB.Data.Models.Entities;
using SW.MB.Domain.Extensions;
using SW.MB.Domain.Models.Records;
using SW.MB.Test.UnitTests.Extensions.Abstracts;

namespace SW.MB.Test.UnitTests.Extensions {
    [TestClass]
    public class MemberExtensionTests : BaseEntityExtensionTests {
        [TestMethod]
        public void ToRecord() {
            MemberEntity entity = CreateEntity();

            MemberRecord record = entity.ToRecord();

            CompareValues(record, entity);
        }

        [TestMethod]
        public void ToEntity() {
            MemberRecord record = CreateRecord();

            MemberEntity entity = record.ToEntity();

            CompareValues(record, entity);
        }

        protected static MemberEntity CreateEntity() {
            return new MemberEntity() {
                ID = Random.Next(),
                Created = DateTime.Now,
                CreatedBy = Random.Next(),
                Updated = DateTime.Now,
                UpdatedBy = Random.Next(),
                Firstname = Random.NextFirstname(),
                Lastname = Random.NextLastname(),
                DateOfBirth = Random.NextDateTimePast(),
                YearsOfJoining = "1965;1998",
                YearsOfSeparation = "1975"
            };
        }

        protected static MemberRecord CreateRecord() {
            return new MemberRecord() {
                ID = Random.Next(),
                Created = DateTime.Now,
                CreatedBy = Random.Next(),
                Updated = DateTime.Now,
                UpdatedBy = Random.Next(),
                Firstname = Random.NextFirstname(),
                Lastname = Random.NextLastname(),
                DateOfBirth = DateOnly.FromDateTime(Random.NextDateTimePast()),
                YearsOfJoining = new int[] { Random.Next(DateTime.Now.Year), Random.Next(DateTime.Now.Year) },
                YearsOfSeparation = new int[] { Random.Next(DateTime.Now.Year) }
            };
        }

        private static void CompareValues(MemberRecord record, MemberEntity entity) {
            Assert.IsNotNull(record);
            Assert.IsNotNull(entity);

            foreach (PropertyInfo propertyInfo in record.GetType().GetProperties()) {
                object? value = propertyInfo.GetValue(record);
                object? reference = entity.GetType().GetProperty(propertyInfo.Name)?.GetValue(entity);

                Assert.IsNotNull(value);
                Assert.IsNotNull(reference);

                if (propertyInfo.PropertyType == typeof(DateOnly?) && value is DateOnly dateOnly && reference is DateTime dateTime) {
                    Assert.IsTrue(dateOnly.Year == dateTime.Year && dateOnly.Month == dateTime.Month && dateOnly.Day == dateTime.Day);
                } else if (value is int[] dateArray && reference is string datesString) {
                    Assert.AreEqual(string.Join(';', dateArray), datesString);
                } else {
                    Assert.AreEqual(value, reference);
                }
            }
        }
    }
}
