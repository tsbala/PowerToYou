using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace PowerToYou.DataAccess.Consumer
{
    public class ConsumerDataProvider
    {
        public static IEnumerable<ConsumptionData> GetData(string pathToSource = "")
        {
            var _fileName = string.IsNullOrEmpty(pathToSource) ? @"..\..\..\AppChallenge\consumerData.xml" : pathToSource;
            var doc = XElement.Load(_fileName);

            return doc.Descendants("consumptionData")
               .Select(consumption => new ConsumptionData
               {
                   Tariff = Convert.ToInt32(consumption.Attribute("tariff").Value)
               });
        }
    }

    public class EnergyData
    {
        public List<ConsumptionData> couldBeAnything { get; set; }
    }

    public class ConsumptionData
    {
        public int Tariff { get; set; }
        public GasConsumption GasConsumption { get; set; }
    }

    public class GasConsumption
    {
        public decimal Jan { get; set; }
    }
}