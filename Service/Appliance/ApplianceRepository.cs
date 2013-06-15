using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace PowerToYou.Service.Appliance
{
    public class ApplianceRepository : IApplianceRepository
    {
        private readonly string _fileName;

        public ApplianceRepository(string fileName)
        {
            _fileName = fileName;
        }

        public IEnumerable<Appliance> GetAppliances()
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