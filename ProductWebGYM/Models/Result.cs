using System.Net;

namespace ProductWebGYM.Models
{
    public struct  class Result
    {
        public int? Id { get; init; }
        public HttpStatusCode StatusCode { get; init; }
        public string ErrorMessage { get; init; }
        public object? CustomObject { get; init; }
    }
}
