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


    }
}