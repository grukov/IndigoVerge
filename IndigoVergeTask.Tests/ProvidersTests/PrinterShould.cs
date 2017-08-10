using IndigoVergeTask.Contracts;
using IndigoVergeTask.Providers;
using Moq;
using NUnit.Framework;
using System;

namespace IndigoVergeTask.Tests.ProvidersTests
{
    [TestFixture]
    public class PrinterShould
    {
        [Test]
        public void ThrowsExceptionWhenWriterIsNull()
        {
            var reader = new Mock<IReader>();

            Assert.Throws<NullReferenceException>(() => new Printer(null, reader.Object));
        }

        [Test]
        public void ThrowsExceptionWhenReaderIsNull()
        {
            var writer = new Mock<IWriter>();

            Assert.Throws<NullReferenceException>(() => new Printer(writer.Object, null));
        }
    }
}
