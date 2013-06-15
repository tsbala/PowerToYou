using System.Linq;
using NUnit.Framework;
using PowerToYou.Service.Appliance;

namespace PowerToYou.Service.Tests
{
    [TestFixture]
    public class ApplianceRepositoryTests
    {
        private ApplianceRepository _applianceRepository;

        [SetUp]
        public void Setup()
        {
            _applianceRepository = new ApplianceRepository(@"C:\Users\Admin\.ssh\PowerToYou\AppChallenge\appliances.xml");
        }

        [Test]
        public void GetAppliances_ReturnsAllAppliancesInTheXMLFile()
        {
            var appliances = _applianceRepository.GetAppliances();
            Assert.IsTrue(appliances.Count() == 27);
            Assert.That(true, Is.True);
        }
    }
}
