using System;
using System.Collections.Generic;
using System.Linq;
using PowerToYou.DataAccess.Consumer;

namespace PowerToYou.Models.Extensions
{
    public static class ConsumptionDataExtensions
    {
        public static IEnumerable<ConsumptionData> ApplyFilters(this IEnumerable<ConsumptionData> consumption,
                                                                IEnumerable<Func<ConsumptionData, bool>> predicates)
        {
            IEnumerable<ConsumptionData> results = consumption;
            foreach (var predicate in predicates)
            {
                results = results.Where(predicate);
            }

            return results;
        }
    }
}