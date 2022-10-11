using Microsoft.EntityFrameworkCore;
using Moq;

namespace SW.MB.Test.UnitTests.Services.Abstracts {
  public abstract class ServiceTestsBase {
    /// <summary>
    /// COMMENT
    /// </summary>
    /// <remarks>
    /// https://stackoverflow.com/questions/31349351/how-to-add-an-item-to-a-mock-dbset-using-moq
    /// </remarks>
    /// <typeparam name="T"></typeparam>
    /// <param name="sourceList"></param>
    /// <returns></returns>
    protected static DbSet<T> GetQueryableMockDbSet<T>(List<T> sourceList) where T : class {
      IQueryable<T> queryable = sourceList.AsQueryable();

      Mock<DbSet<T>> dbSet = new Mock<DbSet<T>>();
      dbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
      dbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
      dbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
      dbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(queryable.GetEnumerator());
      dbSet.Setup(d => d.Add(It.IsAny<T>())).Callback<T>(s => sourceList.Add(s));

      return dbSet.Object;
    }
  }
}
