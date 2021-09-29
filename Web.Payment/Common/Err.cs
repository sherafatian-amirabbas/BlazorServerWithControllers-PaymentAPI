
namespace Web.Payment.Common
{
    public class Err
    {
        public Err(string code, string errorMessage)
        {
            Code = code;
            ErrorMessage = errorMessage;
        }


        public string Code { get; }
        public string ErrorMessage { get; }


        #region Abstract Methods

        public override bool Equals(object obj)
        {
            var ins = (obj as Err);
            return ins != null &&
                ins.Code == this.Code &&
                ins.ErrorMessage == this.ErrorMessage;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion
    }
}
