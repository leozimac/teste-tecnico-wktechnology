using System.Net;

namespace WebApp.DTOs
{
    public class ResponseBase
    {
        public List<string> Messages { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
