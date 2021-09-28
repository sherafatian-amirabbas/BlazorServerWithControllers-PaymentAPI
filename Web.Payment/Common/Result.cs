using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Payment.Common
{
    public class Result<TPayload>
    {
        #region Constructor

        public Result() { }
        public Result(bool succeed) : this()
        {
            Succeed = succeed;
        }

        #endregion

        public bool Succeed { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorCode { get; set; }
        public TPayload Payload { get; set; }
    }
}
