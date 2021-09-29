using System.Collections.Generic;
using System.Linq;


namespace Web.Payment.Common
{
    public class Result : Result<object>
    { }

    public class Result<TPayload>
    {
        #region Constructor

        public Result(bool succeed = false, IEnumerable<Err> Errors = null)
        {
            this.Succeed = succeed;
            this.Errors = Errors ?? Enumerable.Empty<Err>();
        }

        #endregion

        public bool Succeed { get; set; }
        public IEnumerable<Err> Errors { get; set; }
        public TPayload Payload { get; set; }
    }
}
