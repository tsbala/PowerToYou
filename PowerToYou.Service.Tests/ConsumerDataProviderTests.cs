using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using NUnit.Framework;
using PowerToYou.DataAccess.Consumer;

namespace PowerToYou.Service.Tests
{
    [TestFixture]
    public class ConsumerDataProviderTests
    {
        [Test]
        public void WhenDataProviderProvidesData_ThenAllPartsOfTheGraphArePopulated()
        {
            var response = ConsumerDataProvider.GetData();
            Assert.That(response.FirstOrDefault().Tariff, Is.EqualTo(1));
            Assert.That(response.Count(), Is.GreaterThan(1));

            Assert.That(response.FirstOrDefault().GasConsumption.For("jan").Consumption, Is.EqualTo(3929.136000));
            Assert.That(response.FirstOrDefault().GasConsumption.For("dec").Consumption, Is.EqualTo(3615.944000));

            Assert.That(response.FirstOrDefault().ElecricityConsumption.For("jan").Consumption, Is.EqualTo(462.584000));
            Assert.That(response.FirstOrDefault().ElecricityConsumption.For("dec").Consumption, Is.EqualTo(471.312000));
        }

        [Test]
        public void WhenSearchingConsumerDataProvider_IGetTheExpectedResultsBack()
        {
            var data = ConsumerDataProvider.GetData();
            Assert.That(data.Count(x => x.CurrentSupplier == "Best Energy"), Is.EqualTo(7));
            Assert.That(data.Count(x => x.CurrentSupplier == "Energise"), Is.EqualTo(24));

            Assert.That(data.Count(x => x.AreaCode == "11"), Is.EqualTo(6));
            Assert.That(data.Count(x => x.AreaCode == "16"), Is.EqualTo(13));

            Assert.That(data.Count(x => x.LoftInsulation == "Loft Insulation Between 50 and 150mm"), Is.EqualTo(41));
        }
    }
}