using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

using TechTalk.SpecFlow.Assist;

using Web.Payment.SpecFlow.Controller.Support.Retreivers;


namespace Web.Payment.SpecFlow.Controller.Support
{
    public class Helper
    {
        static Lazy<List<IValueRetriever>> retreivers;

        static Helper()
        {
            retreivers = new Lazy<List<IValueRetriever>>(() => ReflectAllRetreivers());
        }


        #region Static Methods

        public static List<IValueRetriever> GetRetreivers()
        {
            return retreivers.Value;
        }

        #endregion


        #region Private Methods

        private static List<IValueRetriever> ReflectAllRetreivers()
        {
            return Assembly.GetAssembly(typeof(Retreiver<>)).GetTypes()
                    .Where(u =>
                        u.IsClass &&
                        !u.IsAbstract &&
                        u.BaseType.IsGenericType &&
                        u.BaseType.GetGenericTypeDefinition() == typeof(Retreiver<>)
                    )
                    .Select(T => (IValueRetriever)Activator.CreateInstance(T))
                    .ToList();
        }

        #endregion
    }
}
