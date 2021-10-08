using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

using TechTalk.SpecFlow.Assist;

using Web.Payment.SpecFlow.Controller.Support.Retreivers;
using Web.Payment.SpecFlow.Controller.Drivers;


namespace Web.Payment.SpecFlow.Controller.Support
{
    public static class Helper
    {
        static Lazy<List<IValueRetriever>> retreivers = new Lazy<List<IValueRetriever>>(() => ReflectAllRetreivers());


        #region Static Methods

        public static List<IValueRetriever> GetRetreivers()
        {
            return retreivers.Value;
        }

        #endregion


        #region Extension Methods

        public static bool ContainsCode(this IEnumerable<SpCreditCardApiResultError> errors, string code)
        {
            return errors != null && errors.Any(u => u.Code == code);
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
