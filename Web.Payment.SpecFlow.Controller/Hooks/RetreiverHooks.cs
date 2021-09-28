using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

using Web.Payment.SpecFlow.Controller.Support;


namespace Web.Payment.SpecFlow.Controller.Hooks
{
    [Binding]
    class RetreiverHooks
    {
        [BeforeScenario]
        public void RegisterRetreivers()
        {
            var retreivers = Helper.GetRetreivers();
            retreivers.ForEach(u =>
            {
                Service.Instance.ValueRetrievers.Unregister(u);
                Service.Instance.ValueRetrievers.Register(u);
            });
        }
    }
}
