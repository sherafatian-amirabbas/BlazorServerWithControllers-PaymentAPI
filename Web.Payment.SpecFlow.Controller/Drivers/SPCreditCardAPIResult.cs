using System.Collections.Generic;


namespace Web.Payment.SpecFlow.Controller.Drivers
{
    public class SpCreditCardApiResult<TPayload>
    {
        public bool Succeed { get; set; }
        public IEnumerable<SpCreditCardApiResultError> Errors { get; set; }
        public TPayload Payload { get; set; }
    }
}
