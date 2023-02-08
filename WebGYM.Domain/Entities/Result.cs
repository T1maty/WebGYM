using System.Net;

namespace WebGYM.Shared.Models
{
    public readonly struct Result
    {
        public int? Id { get; init; }
        public HttpStatusCode StatusCode { get; init; }
        public string ErrorMessage { get; init; }
        public object? CustomObject { get; init; }
    }
}
