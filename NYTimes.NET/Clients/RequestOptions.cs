using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace NYTimes.NET.Clients
{
    /// <summary>
    /// A container for generalized request inputs. This type allows consumers to extend the request functionality
    /// by abstracting away from the default (built-in) request framework (e.g. RestSharp).
    /// </summary>
    public class RequestOptions : IRequestOptions
    {
        /// <summary>
        /// Parameters to be bound to path parts of the Request's URL
        /// </summary>
        public Dictionary<string, string> PathParameters { get; set; }

        /// <summary>
        /// Query parameters to be applied to the request.
        /// Keys may have 1 or more values associated.
        /// </summary>
        public Multimap<string, string> QueryParameters { get; set; }

        /// <summary>
        /// Header parameters to be applied to to the request.
        /// Keys may have 1 or more values associated.
        /// </summary>
        public Multimap<string, string> HeaderParameters { get; set; }

        /// <summary>
        /// Form parameters to be sent along with the request.
        /// </summary>
        public Dictionary<string, string> FormParameters { get; set; }

        /// <summary>
        /// File parameters to be sent along with the request.
        /// </summary>
        public Dictionary<string, Stream> FileParameters { get; set; }

        /// <summary>
        /// Cookies to be sent along with the request.
        /// </summary>
        public List<Cookie> Cookies { get; set; }

        /// <summary>
        /// Any data associated with a request body.
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// Constructs a new instance of <see cref="RequestOptions"/>
        /// </summary>
        public RequestOptions()
        {
            PathParameters = new Dictionary<string, string>();
            QueryParameters = new Multimap<string, string>();
            HeaderParameters = new Multimap<string, string>();
            FormParameters = new Dictionary<string, string>();
            FileParameters = new Dictionary<string, Stream>();
            Cookies = new List<Cookie>();
        }

        public RequestOptions(IReadableConfiguration configuration) : this()
        {
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));
            
            var contentTypes = Array.Empty<string>();

            // to determine the Accept header
            var accepts = new[] {
                "application/json"
            };

            var contentType = ClientUtils.SelectHeaderContentType(contentTypes);
            if (contentType != null) HeaderParameters.Add("Content-Type", contentType);

            var accept = ClientUtils.SelectHeaderAccept(accepts);
            if (accept != null) HeaderParameters.Add("Accept", accept);
            
            // authentication (apikey) required
            if (!string.IsNullOrWhiteSpace(configuration.GetApiKeyWithPrefix("api-key")))
            {
                QueryParameters.Add(
                    ClientUtils.ParameterToMultiMap(
                        "", "api-key", configuration.GetApiKeyWithPrefix("api-key")));
            }
        }
    }
}