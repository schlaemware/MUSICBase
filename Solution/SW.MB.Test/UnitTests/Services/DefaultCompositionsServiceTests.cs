using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SW.MB.Data.Contracts.UnitsOfWork;
using SW.MB.Data.Models.Entities;
using SW.MB.Domain.Contracts.Services;
using SW.MB.Domain.Models.Records;
using SW.MB.Domain.Services;
using SW.MB.Test.UnitTests.Services.Abstracts;

namespace SW.MB.Test.UnitTests.Services {
    [TestClass]
    public class DefaultCompositionsServiceTests : ServiceTestsBase {
        [TestMethod]
        public void GetAll() {
            List<CompositionEntity> sourceList = new() {
        new CompositionEntity(),
      };

            Mock<IUnitOfWork> uowMock = new();
            uowMock.Setup(x => x.Compositions).Returns(() => GetQueryableMockDbSet(sourceList));

            ICompositionsService service = new DefaultCompositionsService(uowMock.Object);
            IEnumerable<CompositionRecord> compositions = service.GetAll();

            Assert.IsNotNull(compositions);
            Assert.IsTrue(compositions.Any());
        }

        [TestMethod]
        public void GetAll_Empty() {
            Mock<IUnitOfWork> uowMock = new();
            uowMock.Setup(x => x.Compositions).Returns(() => GetQueryableMockDbSet(new List<CompositionEntity>()));

            ICompositionsService service = new DefaultCompositionsService(uowMock.Object);
            IEnumerable<CompositionRecord> compositions = service.GetAll();

            Assert.IsNotNull(compositions);
            Assert.IsFalse(compositions.Any());
        }
    }
}