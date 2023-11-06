using Newtonsoft.Json;

namespace CleanArchitecture.WebAPI.Middleware
{
    public sealed class ErrorResult : ErrorStatus
    {
        public string Message { get; set; }
    }

    public class ErrorStatus
    {
        public int StatusCode { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public sealed class ValidationErrorDetails : ErrorStatus
    {
        public IEnumerable<string> Errors { get; set; }
    }
}
