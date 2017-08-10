using IndigoVergeTask.Contracts;
using Moq;
using NUnit.Framework;

namespace IndigoVergeTask.Tests.ProvidersTests
{
    [TestFixture]
    public class EngineShould
    {
        [Test]
        public void CallLogMethodWhenExceptionOccurs()
        {
            var mockedReader = new Mock<IReader>();
            var mockedWriter = new Mock<IWriter>();
            var mockedPrinter = new Mock<IPrinter>();
            var mockedParser = new Mock<IParser>();
            var mockedLogger = new Mock<ILogger>();

            var engine = Engine.Instance(mockedReader.Object, mockedWriter.Object,
                mockedPrinter.Object, mockedParser.Object, mockedLogger.Object);

            mockedReader.Setup(x => x.ReadLine()).Returns(string.Empty);

            engine.Start();

            mockedLogger.Verify(x => x.Log(It.IsAny<string>()), Times.Once);
        }
    }
}
