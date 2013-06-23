using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using PowerToYou.DataAccess.Consumer;
using PowerToYou.Models.Extensions;

namespace PowerToYou.Service.Tests
{
    [TestFixture]
    public class ConsumptionDataExtentionsTest
    {
        [Test]
        public void CanApplyQueryToData()
        {
            var data = ConsumerDataProvider.GetData();
            var firstResults = data.ApplyFilters(new List<Func<ConsumptionData, bool>>()
                {
                    x => x.CurrentSupplier == "Best Energy",
                    x => x.Tariff == 1
                });

            Assert.That(firstResults.Count(), Is.EqualTo(7));

            var secondResults = data.ApplyFilters(new List<Func<ConsumptionData, bool>>()
                {
                    x => x.CurrentSupplier == "Best Energy",
                    x => x.AreaCode == "16"
                });

            Assert.That(firstResults.Count(), Is.EqualTo(2));
        }
    }
}