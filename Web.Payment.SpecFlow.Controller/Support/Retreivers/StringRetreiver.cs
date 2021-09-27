using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow.Assist;
using Web.Payment.SpecFlow.Controller.Support.Retreivers;

namespace Web.Payment.SpecFlow.Controller.Retreivers
{
    class StringRetreiver : Retreiver<string>
    {
        public override object Retrieve(KeyValuePair<string, string> keyValuePair, Type targetType, Type propertyType)
        {
            if (string.Compare(keyValuePair.Value, "<null>", true) == 0)
                return null;

            return keyValuePair.Value;
        }
    }
}
