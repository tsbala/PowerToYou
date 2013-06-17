using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using NUnit.Framework;
using PowerToYou.DataAccess.Appliance;
using PowerToYou.DataAccess.Consumer;

namespace PowerToYou.Service.Tests
{
    [TestFixture]
    public class ApplianceDataProviderTests
    {
        private ApplianceDataProvider _applianceDataProvider;

        [SetUp]
        public void Setup()
        {
            _applianceDataProvider = new ApplianceDataProvider(@"..\..\..\AppChallenge\appliances.xml");
        }

        [Test]
        public void GetAppliances_ReturnsAllAppliancesInTheXMLFile()
        {
            var appliances = _applianceDataProvider.GetAppliances();
            Assert.IsTrue(appliances.Count() == 27);
        }
    }

    public class ConsumerDataProviderTests
    {
        [Test]
        public void CanDeserializeRawXml()
        {
            var response = ConsumerDataProvider.GetData();
            Assert.That(response.FirstOrDefault().Tariff, Is.EqualTo(1));
        }

    }
}
