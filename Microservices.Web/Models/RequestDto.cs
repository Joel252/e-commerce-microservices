using static Microservices.Web.Utility.SD;

namespace Microservices.Web.Models
{
    public class RequestDTO
    {
        public RequestType RequestType { get; set; } = RequestType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
        public string AccessToken { get; set; }
    }
}
