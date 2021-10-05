namespace Web.Payment.Logics.Services
{
    public interface IResultError
    {
        string Code { get; }
        string ErrorMessage { get; }
    }
}
