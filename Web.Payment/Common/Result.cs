using System.Collections.Generic;
using System.Linq;

using Web.Payment.Logics.Services;


namespace Web.Payment.Common
{
    public class Result : Result<object>
    { }

    public class Result<TPayload> : IResult<TPayload>
        where TPayload : class
    {
        #region Constructor

        public Result(bool succeed = false, IEnumerable<ResultError> Errors = null, TPayload payload = null)
        {
            this.Succeed = succeed;
            this.Errors = Errors ?? Enumerable.Empty<ResultError>();
            this.Payload = payload;
        }

        #endregion

        public bool Succeed { get; set; }
        public IEnumerable<IResultError> Errors { get; set; }
        public TPayload Payload { get; set; }
    }
}
