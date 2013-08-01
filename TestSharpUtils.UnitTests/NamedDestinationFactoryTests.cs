using System;
using NUnit.Framework;
using TS.Utilities;
using iTextSharp.text.pdf;

namespace TestSharpUtils.UnitTests
{
    [TestFixture]
    public class NamedDestinationFactoryTests
    {
        #region GetPDFViewTypeTests
        [Test]
        public void NamedDestinationFactory_Returns_FIT_When_GetPDFViewType_Is_Called_On_FIT()
        {
            var result = NamedDestinationFactory.GetPDFViewType("FIT");
            Assert.AreEqual(result, PdfDestination.FIT);
        }

        [Test]
        public void NamedDestinationFactory_Returns_FITB_When_GetPDFViewType_Is_Called_On_FITB()
        {
            var result = NamedDestinationFactory.GetPDFViewType("FITB");
            Assert.AreEqual(result, PdfDestination.FITB);
        }

        [Test]
        public void NamedDestinationFactory_Returns_FITBH_When_GetPDFViewType_Is_Called_On_FITBH()
        {
            var result = NamedDestinationFactory.GetPDFViewType("FITBH");
            Assert.AreEqual(result, PdfDestination.FITBH);
        }

        [Test]
        public void NamedDestinationFactory_Returns_FITBV_When_GetPDFViewType_Is_Called_On_FITBV()
        {
            var result = NamedDestinationFactory.GetPDFViewType("FITBV");
            Assert.AreEqual(result, PdfDestination.FITBV);
        }

        [Test]
        public void NamedDestinationFactory_Returns_FITH_When_GetPDFViewType_Is_Called_On_FITH()
        {
            var result = NamedDestinationFactory.GetPDFViewType("FITH");
            Assert.AreEqual(result, PdfDestination.FITH);
        }

        [Test]
        public void NamedDestinationFactory_Returns_FITR_When_GetPDFViewType_Is_Called_On_FITR()
        {
            var result = NamedDestinationFactory.GetPDFViewType("FITR");
            Assert.AreEqual(result, PdfDestination.FITR);
        }

        [Test]
        public void NamedDestinationFactory_Returns_FITV_When_GetPDFViewType_Is_Called_On_FITV()
        {
            var result = NamedDestinationFactory.GetPDFViewType("FITV");
            Assert.AreEqual(result, PdfDestination.FITV);
        }

        [Test]
        public void NamedDestinationFactory_Returns_XYZ_When_GetPDFViewType_Is_Called_On_AnythingElse()
        {
            var result = NamedDestinationFactory.GetPDFViewType(Guid.NewGuid().ToString());
            Assert.AreEqual(result, PdfDestination.XYZ);
        }
        #endregion

        #region CreateNamedInstanceForTests
        
        
        #endregion
    }
}