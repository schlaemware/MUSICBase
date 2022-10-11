using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SW.Framework.Extensions;
using SW.MB.Data.Models.Entities;
using SW.MB.Domain.Extensions;
using SW.MB.Domain.Models.Records;
using SW.MB.Test.UnitTests.Extensions.Abstracts;

namespace SW.MB.Test.UnitTests.Extensions {
  [TestClass]
  public class MusicianExtensionTests: BaseEntityExtensionTests {
    [TestMethod]
    public void ToRecord() {
      MusicianEntity entity = CreateEntity();

      MusicianRecord record = entity.ToRecord();

      CompareValues(record, entity);
    }

    [TestMethod]
    public void ToEntity() {
      MusicianRecord record = CreateRecord();

      MusicianEntity entity = record.ToEntity();

      CompareValues(record, entity);
    }

    protected static MusicianEntity CreateEntity() {
      return new MusicianEntity() {
        ID = Random.Next(),
        Created = DateTime.Now,
        CreatedBy = Random.Next(),
        Updated = DateTime.Now,
        UpdatedBy = Random.Next(),
        Firstname = Random.NextFirstname(),
        Lastname = Random.NextLastname(),
        DateOfBirth = Random.NextDateTimePast(),
        DateOfDeath = Random.NextDateTimePast(),
      };
    }

    protected static MusicianRecord CreateRecord() {
      return new MusicianRecord() {
        ID = Random.Next(),
        Created = DateTime.Now,
        CreatedBy = Random.Next(),
        Updated = DateTime.Now,
        UpdatedBy = Random.Next(),
        Firstname = Random.NextFirstname(),
        Lastname = Random.NextLastname(),
        DateOfBirth = DateOnly.FromDateTime(Random.NextDateTimePast()),
        DateOfDeath = DateOnly.FromDateTime(Random.NextDateTimePast()),
      };
    }

    private static void CompareValues(MusicianRecord record, MusicianEntity entity) {
      Assert.IsNotNull(record);
      Assert.IsNotNull(entity);

      foreach (PropertyInfo propertyInfo in record.GetType().GetProperties()) {
        object? value = propertyInfo.GetValue(record);
        object? reference = entity.GetType().GetProperty(propertyInfo.Name)?.GetValue(entity);

        Assert.IsNotNull(value);
        Assert.IsNotNull(reference);

        if (propertyInfo.PropertyType == typeof(DateOnly?) && value is DateOnly dateOnly && reference is DateTime dateTime) {
          Assert.IsTrue(dateOnly.Year == dateTime.Year && dateOnly.Month == dateTime.Month && dateOnly.Day == dateTime.Day);
        } else {
          Assert.AreEqual(value, reference);
        }
      }
    }
  }
}
