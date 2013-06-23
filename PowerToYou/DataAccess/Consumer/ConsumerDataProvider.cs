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
            var _fileName = string.IsNullOrEmpty(pathToSource)
                                ? @"..\..\..\AppChallenge\consumerData.xml"
                                : pathToSource;
            var doc = XElement.Load(_fileName);

            return doc.Descendants("consumptionData")
                      .Select(consumption => new ConsumptionData
                          {
                              Tariff = Convert.ToInt32(consumption.Attribute("tariff").Value),
                              CurrentSupplier = consumption.Attribute("currentSupplier").Value,
                              Postcode = consumption.Attribute("Postcode").Value,
                              AreaCode = consumption.Attribute("areaCode").Value,
                              PropertyType = consumption.Attribute("propertyType").Value,
                              Bedrooms = consumption.Attribute("bedrooms").Value,
                              YearBuilt = consumption.Attribute("propertyBuilt").Value,
                              NumberOfBathrooms = Convert.ToInt32(consumption.Attribute("numberofBathrooms").Value),
                              ElectricityKwh = Convert.ToDecimal(consumption.Attribute("electricityKwh").Value),
                              GasKwh = Convert.ToDecimal(consumption.Attribute("gasKwh").Value),
                              CentralHeating = consumption.Attribute("centralHeating").Value,
                              LoftInsulation = consumption.Attribute("loftInsulation").Value,
                              WallType = consumption.Attribute("wallType").Value, 

                              GasConsumption = GetGasConsumption(consumption)


                              

                          });
        }

        private static GasConsumption GetGasConsumption(XElement consumption)
        {
            var gasConsumption = new GasConsumption();
            foreach (var attribute in consumption.Descendants("gasConsumption").Attributes())
            {
                gasConsumption.Add(new MontlyConsumption(attribute.Name.ToString(), Convert.ToDecimal(attribute.Value)));
               
            }

            return gasConsumption; 
        }
    }

    public class EnergyData
    {
        public List<ConsumptionData> couldBeAnything { get; set; }
    }

    public class ConsumptionData
    {
        public int Tariff { get; set; }
        public string CurrentSupplier { get; set; }
        public string Postcode { get; set; }
        public string AreaCode { get; set; }
        public string PropertyType { get; set; }
        public string Bedrooms { get; set; }
        public string YearBuilt { get; set; }
        public int NumberOfBathrooms { get; set; }
        public decimal ElectricityKwh { get; set; }
        public decimal GasKwh { get; set; }
        public string CentralHeating { get; set; }
        public string LoftInsulation { get; set; }
        public string WallType { get; set; }

        public ElectricityConsumption ElecricityConsumption { get; set; }
        public GasConsumption GasConsumption { get; set; }
    }

    public class GasConsumption : List<MontlyConsumption>
    {
        public MontlyConsumption For(string month)
        {
            return this.FirstOrDefault(x => x.Month == month);
        }
    }

    public class ElectricityConsumption : List<MontlyConsumption>
    {
        public MontlyConsumption For(string month)
        {
            return this.FirstOrDefault(x => x.Month == month);
        }
    }

    public class MontlyConsumption
    {
        public MontlyConsumption(string month, decimal consumption)
        {
            Month = month;
            Consumption = consumption;
        }

        public string Month { get; set; }
        public decimal Consumption { get; set; }
    }
}