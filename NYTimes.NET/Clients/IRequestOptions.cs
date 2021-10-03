using System.Collections.Generic;
using System.IO;
using System.Net;

namespace NYTimes.NET.Clients
{
    public interface IRequestOptions
    {
        /// <summary>
        /// Parameters to be bound to path parts of the Request's URL
        /// </summary>
        Dictionary<string, string> PathParameters { get; set; }

        /// <summary>
        /// Query parameters to be applied to the request.
        /// Keys may have 1 or more values associated.
        /// </summary>
        Multimap<string, string> QueryParameters { get; set; }

        /// <summary>
        /// Header parameters to be applied to to the request.
        /// Keys may have 1 or more values associated.
        /// </summary>
        Multimap<string, string> HeaderParameters { get; set; }

        /// <summary>
        /// Form parameters to be sent along with the request.
        /// </summary>
        Dictionary<string, string> FormParameters { get; set; }

        /// <summary>
        /// File parameters to be sent along with the request.
        /// </summary>
        Dictionary<string, Stream> FileParameters { get; set; }

        /// <summary>
        /// Cookies to be sent along with the request.
        /// </summary>
        List<Cookie> Cookies { get; set; }

        /// <summary>
        /// Any data associated with a request body.
        /// </summary>
        object Data { get; set; }
    }
}