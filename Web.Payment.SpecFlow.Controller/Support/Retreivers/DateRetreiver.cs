using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow.Assist;
using Web.Payment.SpecFlow.Controller.Support.Retreivers;

namespace Web.Payment.SpecFlow.Controller.Retreivers
{
    class DateRetreiver : Retreiver<DateTime>
    {
        public override object Retrieve(KeyValuePair<string, string> keyValuePair, Type targetType, Type propertyType)
        {
            if (string.Compare(keyValuePair.Value, "<null>", true) == 0)
                return null;

            if (string.Compare(keyValuePair.Value, "<today>", true) == 0)
                return DateTime.Now;

            if (string.Compare(keyValuePair.Value, "<next_day>", true) == 0)
                return DateTime.Now.AddDays(1);

            if (string.Compare(keyValuePair.Value, "<last_day>", true) == 0)
                return DateTime.Now.AddDays(-1);

            if (string.Compare(keyValuePair.Value, "<next_month>", true) == 0)
                return DateTime.Now.AddMonths(1);

            if (string.Compare(keyValuePair.Value, "<last_month>", true) == 0)
                return DateTime.Now.AddMonths(-1);

            return keyValuePair.Value;
        }
    }
}
