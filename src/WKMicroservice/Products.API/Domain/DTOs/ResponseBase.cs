using System.Net;

namespace Products.API.Domain.DTOs
{
    public class ResponseBase
    {
        public List<string> Messages { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        public ResponseBase()
        {
            Messages = new List<string>();
        }
    }
}
