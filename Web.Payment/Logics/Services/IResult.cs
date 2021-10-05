using System.Collections.Generic;


namespace Web.Payment.Logics.Services
{
    public interface IResult<TPayload>
        where TPayload : class
    {
        bool Succeed { get; }
        IEnumerable<IResultError> Errors { get; }
        TPayload Payload { get; }
    }
}
