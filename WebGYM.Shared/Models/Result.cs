using System.Net;

namespace WebGYM.Shared.Models
{
    public readonly struct Result<T>
    {
        public int? Id { get; init; }
        public HttpStatusCode StatusCode { get; init; }
        public string ErrorMessage { get; init; }
        public T? CustomObject { get; init; }
    }
}
