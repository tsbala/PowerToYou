﻿using System.Collections.Generic;

namespace PowerToYou.Service.Appliance
{
    public interface IApplianceRepository
    {
        IEnumerable<Appliance> GetAppliances();
    }

    public class Appliance
    {
        public string Name { get; set; }
        public double Wattage { get; set; }
    }
}
