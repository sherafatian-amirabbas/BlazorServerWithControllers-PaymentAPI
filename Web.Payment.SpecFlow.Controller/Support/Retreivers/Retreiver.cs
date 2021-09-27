using System;
using System.Collections.Generic;

using TechTalk.SpecFlow.Assist;


namespace Web.Payment.SpecFlow.Controller.Support.Retreivers
{
    abstract class Retreiver<T> : IValueRetriever
    {
        public bool CanRetrieve(KeyValuePair<string, string> keyValuePair, Type targetType, Type propertyType)
        {
            return propertyType == typeof(T);
        }

        public abstract object Retrieve(KeyValuePair<string, string> keyValuePair, Type targetType, Type propertyType);
    }
}
