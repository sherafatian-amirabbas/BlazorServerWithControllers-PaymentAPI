using System.Collections.Generic;


namespace Web.Payment.SpecFlow.Controller.Drivers
{
    public class SPCreditCardAPIResult<TPayload>
    {
        public bool Succeed { get; set; }
        public IEnumerable<SPCreditCardAPIResultError> Errors { get; set; }
        public TPayload Payload { get; set; }
    }
}
