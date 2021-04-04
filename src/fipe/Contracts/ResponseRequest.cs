using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace fipe.Contracts
{
    [ExcludeFromCodeCoverage]
    public class ResponseRequest
    {
        public ResponseRequest(string body, HttpStatusCode statuscode)
        {
            Body = body;
            StatusCode = statuscode;
        }

        public string Body { get;  }
        public HttpStatusCode StatusCode { get;  }


    }
}
