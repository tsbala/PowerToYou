using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using PowerToYou.Service.Appliance;

namespace PowerToYou.DataAccess.Appliance
{
    public class ApplianceDataProvider : IApplianceDataProvider
    {
        private readonly string _fileName;

        public ApplianceDataProvider(string fileName)
        {
            _fileName = fileName;
        }

        public IEnumerable<Service.Appliance.Appliance> GetAppliances()
        {
            var doc = XElement.Load(_fileName);

            return doc.Descendants("appliance")
               .Select(appliance => new Service.Appliance.Appliance
                {
                    Name = appliance.Attribute("name").Value,
                    Wattage = Convert.ToDouble(appliance.Attribute("wattage").Value)
                });
        }
    }
}