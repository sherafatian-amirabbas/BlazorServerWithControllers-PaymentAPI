using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Payment.Common
{
    public class ApiResult<TPayload>
    {
        #region Constructor

        public ApiResult() { }
        public ApiResult(bool succeed) : this()
        {
            Succeed = succeed;
        }

        public ApiResult(bool succeed, int statusCode) : this(succeed)
        {
            this.StatusCode = statusCode;
        }

        #endregion

        public bool Succeed { get; set; }
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorCode { get; set; }
        public TPayload Payload { get; set; }
    }
}
