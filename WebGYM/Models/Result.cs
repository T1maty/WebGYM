using System.Net;

namespace WebGYM.Models
{
    public struct Result
    {
        public int? Id { get; init; }
        public HttpStatusCode StatusCode { get; init; }
        public string ErrorMessage { get; init; }
        public object? CustomObject { get; init; }
    }
}
