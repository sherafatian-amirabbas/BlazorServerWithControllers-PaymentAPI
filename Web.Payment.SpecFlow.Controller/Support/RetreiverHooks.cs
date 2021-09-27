using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

using Web.Payment.SpecFlow.Controller.Support.Retreivers;


namespace Web.Payment.SpecFlow.Controller.Support
{
    [Binding]
    class RetreiverHooks
    {
        static Lazy<List<IValueRetriever>> retreivers;


        #region static constructor

        static RetreiverHooks()
        {
            retreivers = new Lazy<List<IValueRetriever>>(() => GetAllretreivers());
        }

        #endregion


        [BeforeScenario]
        public void RegisterRetreivers()
        {
            retreivers.Value.ForEach(u =>
            {
                Service.Instance.ValueRetrievers.Unregister(u);
                Service.Instance.ValueRetrievers.Register(u);
            });
        }


        #region private methods

        static private List<IValueRetriever> GetAllretreivers()
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
