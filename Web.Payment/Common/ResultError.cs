using Web.Payment.Logics.Services;


namespace Web.Payment.Common
{
    public class ResultError : IResultError
    {
        public ResultError(string code, string errorMessage)
        {
            Code = code;
            ErrorMessage = errorMessage;
        }


        public string Code { get; }
        public string ErrorMessage { get; }


        #region Abstract Methods

        public override bool Equals(object obj)
        {
            var ins = (obj as ResultError);
            return ins != null &&
                ins.Code == this.Code &&
                ins.ErrorMessage == this.ErrorMessage;
        }

        public override int GetHashCode()
        {
            return (this.Code + this.ErrorMessage).GetHashCode();
        }

        #endregion
    }
}
