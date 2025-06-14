﻿using static Microservices.Web.Utility.SD;

namespace Microservices.Web.Models
{
    public class RequestDto
    {
        public RequestType RequestType { get; set; } = RequestType.Get;
        public string Url { get; set; }
        public object Data { get; set; }
        public string AccessToken { get; set; }
    }
}
