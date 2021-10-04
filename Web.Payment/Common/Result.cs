using System.Collections.Generic;
using System.Linq;


namespace Web.Payment.Common
{
    public class Result : Result<object>
    { }

    public class Result<TPayload>
    {
        #region Constructor

        public Result(bool succeed = false, IEnumerable<ResultError> Errors = null)
        {
            this.Succeed = succeed;
            this.Errors = Errors ?? Enumerable.Empty<ResultError>();
        }

        #endregion

        public bool Succeed { get; set; }
        public IEnumerable<ResultError> Errors { get; set; }
        public TPayload Payload { get; set; }
    }
}
