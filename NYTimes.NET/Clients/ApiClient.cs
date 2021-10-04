using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NYTimes.NET.Models;
using Polly;
using RestSharp;
using RestSharp.Deserializers;
using HttpMethod = System.Net.Http.HttpMethod;
using RestSharpMethod = RestSharp.Method;

namespace NYTimes.NET.Clients
{
    /// <summary>
    /// Provides a default implementation of an Api client (both synchronous and asynchronous implementations),
    /// encapsulating general REST accessor use cases.
    /// </summary>
    public class ApiClient : ISynchronousClient, IAsynchronousClient
    {
        private readonly string _baseUrl;

        /// <summary>
        /// Specifies the settings on a <see cref="System.Text.Json.JsonSerializer" /> object.
        /// These settings can be adjusted to accommodate custom serialization rules.
        /// </summary>
        protected JsonSerializerSettings SerializerSettings { get; set; } = new()
        {
            // OpenAPI generated types generally hide default constructors.
            ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy
                {
                    OverrideSpecifiedNames = false
                }
            }
        };

        /// <summary>
        /// Allows for extending request processing for <see cref="ApiClient"/> generated code.
        /// </summary>
        /// <param name="request">The RestSharp request object</param>
        protected virtual void InterceptRequest(IRestRequest request)
        {
        }

        /// <summary>
        /// Allows for extending response processing for <see cref="ApiClient"/> generated code.
        /// </summary>
        /// <param name="request">The RestSharp request object</param>
        /// <param name="response">The RestSharp response object</param>
        protected virtual void InterceptResponse(IRestRequest request, IRestResponse response)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiClient" />, defaulting to the global configurations' base url.
        /// </summary>
        public ApiClient()
        {
            _baseUrl = GlobalConfiguration.Instance.BasePath;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiClient" />
        /// </summary>
        /// <param name="basePath">The target service's base path in URL format.</param>
        /// <exception cref="ArgumentException"></exception>
        public ApiClient(string basePath)
        {
            if (string.IsNullOrEmpty(basePath))
                throw new ArgumentException("basePath cannot be empty");

            _baseUrl = basePath;
        }

        /// <summary>
        /// Constructs the RestSharp version of an http method
        /// </summary>
        /// <param name="method">Swagger Client Custom HttpMethod</param>
        /// <returns>RestSharp's HttpMethod instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        private static RestSharpMethod Method(HttpMethod method)
        {
            var other = method switch
            {
                var value when value == HttpMethod.Get => RestSharpMethod.GET,
                var value when value == HttpMethod.Post => RestSharpMethod.POST,
                var value when value == HttpMethod.Put => RestSharpMethod.PUT,
                var value when value == HttpMethod.Delete => RestSharpMethod.DELETE,
                var value when value == HttpMethod.Head => RestSharpMethod.HEAD,
                var value when value == HttpMethod.Options => RestSharpMethod.OPTIONS,
                var value when value == HttpMethod.Patch => RestSharpMethod.PATCH,
                _ => throw new ArgumentOutOfRangeException(nameof(method), method, null)
            };

            return other;
        }

        /// <summary>
        /// Provides all logic for constructing a new RestSharp <see cref="RestRequest"/>.
        /// At this point, all information for querying the service is known. Here, it is simply
        /// mapped into the RestSharp request.
        /// </summary>
        /// <param name="method">The http verb.</param>
        /// <param name="path">The target path (or resource).</param>
        /// <param name="options">The additional request options.</param>
        /// <param name="configuration">A per-request configuration object. It is assumed that any merge with
        /// GlobalConfiguration has been done before calling this method.</param>
        /// <returns>[private] A new RestRequest instance.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        private RestRequest NewRequest(
            HttpMethod method,
            string path,
            IRequestOptions options,
            IReadableConfiguration configuration)
        {
            if (path == null) throw new ArgumentNullException(nameof(path));
            if (options == null) throw new ArgumentNullException(nameof(options));
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));

            var request = new RestRequest(Method(method))
            {
                Resource = path,
                JsonSerializer = new CustomJsonCodec(SerializerSettings, configuration)
            };

            if (options.PathParameters != null)
            {
                foreach (var pathParam in options.PathParameters)
                {
                    request.AddParameter(pathParam.Key, pathParam.Value, ParameterType.UrlSegment);
                }
            }

            if (options.QueryParameters != null)
            {
                foreach (var queryParam in options.QueryParameters)
                {
                    foreach (var value in queryParam.Value)
                    {
                        request.AddQueryParameter(queryParam.Key, value);
                    }
                }
            }

            if (configuration.DefaultHeaders != null)
            {
                foreach (var headerParam in configuration.DefaultHeaders)
                {
                    request.AddHeader(headerParam.Key, headerParam.Value);
                }
            }

            if (options.HeaderParameters != null)
            {
                foreach (var headerParam in options.HeaderParameters)
                {
                    foreach (var value in headerParam.Value)
                    {
                        request.AddHeader(headerParam.Key, value);
                    }
                }
            }

            if (options.FormParameters != null)
            {
                foreach (var formParam in options.FormParameters)
                {
                    request.AddParameter(formParam.Key, formParam.Value);
                }
            }

            if (options.Data != null)
            {
                if (options.Data is Stream stream)
                {
                    var contentType = "application/octet-stream";
                    if (options.HeaderParameters != null)
                    {
                        var contentTypes = options.HeaderParameters["Content-Type"];
                        contentType = contentTypes[0];
                    }

                    var bytes = ClientUtils.ReadAsBytes(stream);
                    request.AddParameter(contentType, bytes, ParameterType.RequestBody);
                }
                else
                {
                    if (options.HeaderParameters != null)
                    {
                        var contentTypes = options.HeaderParameters["Content-Type"];
                        if (contentTypes == null || contentTypes.Any(header => header.Contains("application/json")))
                        {
                            request.RequestFormat = DataFormat.Json;
                        }
                        else
                        {
                            // TODO: Generated client user should add additional handlers. RestSharp only supports XML and JSON, with XML as default.
                        }
                    }
                    else
                    {
                        // Here, we'll assume JSON APIs are more common. XML can be forced by adding produces/consumes to openapi spec explicitly.
                        request.RequestFormat = DataFormat.Json;
                    }

                    request.AddJsonBody(options.Data);
                }
            }

            if (options.FileParameters != null)
            {
                foreach (var fileParam in options.FileParameters)
                {
                    var bytes = ClientUtils.ReadAsBytes(fileParam.Value);
                    request.Files.Add(fileParam.Value is FileStream fileStream
                        ? FileParameter.Create(fileParam.Key, bytes, Path.GetFileName(fileStream.Name))
                        : FileParameter.Create(fileParam.Key, bytes, "no_file_name_provided"));
                }
            }

            if (options.Cookies is not {Count: > 0}) return request;
            foreach (var cookie in options.Cookies)
            {
                request.AddCookie(cookie.Name, cookie.Value);
            }

            return request;
        }

        private static ApiResponse<T> ToApiResponse<T>(IRestResponse<T> response)
        {
            var result = response.Data;
            var rawContent = response.Content;

            var transformed = new ApiResponse<T>(response.StatusCode, new Multimap<string, string>(), result, rawContent)
            {
                ErrorText = response.ErrorMessage,
                Cookies = new List<Cookie>()
            };

            foreach (var responseHeader in response.Headers)
            {
                transformed.Headers.Add(responseHeader.Name, ClientUtils.ParameterToString(responseHeader.Value));
            }

            foreach (var responseCookies in response.Cookies)
            {
                transformed.Cookies.Add(
                    new Cookie(
                        responseCookies.Name,
                        responseCookies.Value,
                        responseCookies.Path,
                        responseCookies.Domain)
                );
            }

            return transformed;
        }

        private ApiResponse<T> Exec<T>(RestRequest req, IReadableConfiguration configuration)
        {
            var client = new RestClient(_baseUrl);

            client.ClearHandlers();
            if (req.JsonSerializer is IDeserializer existingDeserializer)
            {
                client.AddHandler("application/json", () => existingDeserializer);
                client.AddHandler("text/json", () => existingDeserializer);
                client.AddHandler("text/x-json", () => existingDeserializer);
                client.AddHandler("text/javascript", () => existingDeserializer);
                client.AddHandler("*+json", () => existingDeserializer);
            }
            else
            {
                var customDeserializer = new CustomJsonCodec(SerializerSettings, configuration);
                client.AddHandler("application/json", () => customDeserializer);
                client.AddHandler("text/json", () => customDeserializer);
                client.AddHandler("text/x-json", () => customDeserializer);
                client.AddHandler("text/javascript", () => customDeserializer);
                client.AddHandler("*+json", () => customDeserializer);
            }

            var xmlDeserializer = new XmlDeserializer();
            client.AddHandler("application/xml", () => xmlDeserializer);
            client.AddHandler("text/xml", () => xmlDeserializer);
            client.AddHandler("*+xml", () => xmlDeserializer);
            client.AddHandler("*", () => xmlDeserializer);

            client.Timeout = configuration.Timeout;

            if (configuration.Proxy != null)
            {
                client.Proxy = configuration.Proxy;
            }

            if (configuration.UserAgent != null)
            {
                client.UserAgent = configuration.UserAgent;
            }

            if (configuration.ClientCertificates != null)
            {
                client.ClientCertificates = configuration.ClientCertificates;
            }

            InterceptRequest(req);

            IRestResponse<T> response;
            if (RetryConfiguration.RetryPolicy != null)
            {
                var policy = RetryConfiguration.RetryPolicy;
                var policyResult = policy.ExecuteAndCapture(() => client.Execute(req));
                response = (policyResult.Outcome == OutcomeType.Successful) ? client.Deserialize<T>(policyResult.Result) : new RestResponse<T>
                {
                    Request = req,
                    ErrorException = policyResult.FinalException
                };
            }
            else
            {
                response = client.Execute<T>(req);
            }

            // if the response type is oneOf/anyOf, call FromJSON to deserialize the data
            if (typeof(AbstractOpenAPISchema).IsAssignableFrom(typeof(T)))
            {
                try
                {
                    response.Data = (T) typeof(T).GetMethod("FromJson")?.Invoke(null, new object[] { response.Content });
                }
                catch (Exception ex)
                {
                    throw ex.InnerException ?? ex;
                }
            }
            else if (typeof(T).Name == "Stream") // for binary response
            {
                response.Data = (T)(object)new MemoryStream(response.RawBytes);
            }

            InterceptResponse(req, response);

            var result = ToApiResponse(response);
            result.ErrorText = response.ErrorMessage;

            if (response.Cookies.Count <= 0) return result;
            result.Cookies ??= new List<Cookie>();
            foreach (var restResponseCookie in response.Cookies)
            {
                var cookie = new Cookie(
                    restResponseCookie.Name,
                    restResponseCookie.Value,
                    restResponseCookie.Path,
                    restResponseCookie.Domain
                )
                {
                    Comment = restResponseCookie.Comment,
                    CommentUri = restResponseCookie.CommentUri,
                    Discard = restResponseCookie.Discard,
                    Expired = restResponseCookie.Expired,
                    Expires = restResponseCookie.Expires,
                    HttpOnly = restResponseCookie.HttpOnly,
                    Port = restResponseCookie.Port,
                    Secure = restResponseCookie.Secure,
                    Version = restResponseCookie.Version
                };

                result.Cookies.Add(cookie);
            }
            return result;
        }

        private async Task<ApiResponse<T>> ExecAsync<T>(RestRequest req, IReadableConfiguration configuration, System.Threading.CancellationToken cancellationToken = default)
        {
            RestClient client = new RestClient(_baseUrl);

            client.ClearHandlers();
            var existingDeserializer = req.JsonSerializer as IDeserializer;
            if (existingDeserializer != null)
            {
                client.AddHandler("application/json", () => existingDeserializer);
                client.AddHandler("text/json", () => existingDeserializer);
                client.AddHandler("text/x-json", () => existingDeserializer);
                client.AddHandler("text/javascript", () => existingDeserializer);
                client.AddHandler("*+json", () => existingDeserializer);
            }
            else
            {
                var customDeserializer = new CustomJsonCodec(SerializerSettings, configuration);
                client.AddHandler("application/json", () => customDeserializer);
                client.AddHandler("text/json", () => customDeserializer);
                client.AddHandler("text/x-json", () => customDeserializer);
                client.AddHandler("text/javascript", () => customDeserializer);
                client.AddHandler("*+json", () => customDeserializer);
            }

            var xmlDeserializer = new XmlDeserializer();
            client.AddHandler("application/xml", () => xmlDeserializer);
            client.AddHandler("text/xml", () => xmlDeserializer);
            client.AddHandler("*+xml", () => xmlDeserializer);
            client.AddHandler("*", () => xmlDeserializer);

            client.Timeout = configuration.Timeout;

            if (configuration.Proxy != null)
            {
                client.Proxy = configuration.Proxy;
            }

            if (configuration.UserAgent != null)
            {
                client.UserAgent = configuration.UserAgent;
            }

            if (configuration.ClientCertificates != null)
            {
                client.ClientCertificates = configuration.ClientCertificates;
            }

            InterceptRequest(req);

            IRestResponse<T> response;
            if (RetryConfiguration.AsyncRetryPolicy != null)
            {
                var policy = RetryConfiguration.AsyncRetryPolicy;
                var policyResult = await policy.ExecuteAndCaptureAsync((ct) => client.ExecuteAsync(req, ct), cancellationToken).ConfigureAwait(false);
                response = (policyResult.Outcome == OutcomeType.Successful) ? client.Deserialize<T>(policyResult.Result) : new RestResponse<T>
                {
                    Request = req,
                    ErrorException = policyResult.FinalException
                };
            }
            else
            {
                response = await client.ExecuteAsync<T>(req, cancellationToken).ConfigureAwait(false);
            }

            // if the response type is oneOf/anyOf, call FromJSON to deserialize the data
            if (typeof(AbstractOpenAPISchema).IsAssignableFrom(typeof(T)))
            {
                response.Data = (T) typeof(T).GetMethod("FromJson")?.Invoke(null, new object[] { response.Content });
            }
            else if (typeof(T).Name == "Stream") // for binary response
            {
                response.Data = (T)(object)new MemoryStream(response.RawBytes);
            }

            InterceptResponse(req, response);

            var result = ToApiResponse(response);
            result.ErrorText = response.ErrorMessage;

            if (response.Cookies.Count <= 0) return result;
            result.Cookies ??= new List<Cookie>();
            foreach (var restResponseCookie in response.Cookies)
            {
                var cookie = new Cookie(
                    restResponseCookie.Name,
                    restResponseCookie.Value,
                    restResponseCookie.Path,
                    restResponseCookie.Domain
                )
                {
                    Comment = restResponseCookie.Comment,
                    CommentUri = restResponseCookie.CommentUri,
                    Discard = restResponseCookie.Discard,
                    Expired = restResponseCookie.Expired,
                    Expires = restResponseCookie.Expires,
                    HttpOnly = restResponseCookie.HttpOnly,
                    Port = restResponseCookie.Port,
                    Secure = restResponseCookie.Secure,
                    Version = restResponseCookie.Version
                };

                result.Cookies.Add(cookie);
            }
            return result;
        }

        #region IAsynchronousClient
        /// <summary>
        /// Make a HTTP GET request (async).
        /// </summary>
        /// <param name="path">The target path (or resource).</param>
        /// <param name="options">The additional request options.</param>
        /// <param name="configuration">A per-request configuration object. It is assumed that any merge with
        /// GlobalConfiguration has been done before calling this method.</param>
        /// <param name="cancellationToken">Token that enables callers to cancel the request.</param>
        /// <returns>A Task containing ApiResponse</returns>
        public Task<ApiResponse<T>> GetAsync<T>(string path, IRequestOptions options, IReadableConfiguration configuration = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            var config = configuration ?? GlobalConfiguration.Instance;
            return ExecAsync<T>(NewRequest(HttpMethod.Get, path, options, config), config, cancellationToken);
        }

        /// <summary>
        /// Make a HTTP POST request (async).
        /// </summary>
        /// <param name="path">The target path (or resource).</param>
        /// <param name="options">The additional request options.</param>
        /// <param name="configuration">A per-request configuration object. It is assumed that any merge with
        /// GlobalConfiguration has been done before calling this method.</param>
        /// <param name="cancellationToken">Token that enables callers to cancel the request.</param>
        /// <returns>A Task containing ApiResponse</returns>
        public Task<ApiResponse<T>> PostAsync<T>(string path, IRequestOptions options, IReadableConfiguration configuration = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            var config = configuration ?? GlobalConfiguration.Instance;
            return ExecAsync<T>(NewRequest(HttpMethod.Post, path, options, config), config, cancellationToken);
        }

        /// <summary>
        /// Make a HTTP PUT request (async).
        /// </summary>
        /// <param name="path">The target path (or resource).</param>
        /// <param name="options">The additional request options.</param>
        /// <param name="configuration">A per-request configuration object. It is assumed that any merge with
        /// GlobalConfiguration has been done before calling this method.</param>
        /// <param name="cancellationToken">Token that enables callers to cancel the request.</param>
        /// <returns>A Task containing ApiResponse</returns>
        public Task<ApiResponse<T>> PutAsync<T>(string path, IRequestOptions options, IReadableConfiguration configuration = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            var config = configuration ?? GlobalConfiguration.Instance;
            return ExecAsync<T>(NewRequest(HttpMethod.Put, path, options, config), config, cancellationToken);
        }

        /// <summary>
        /// Make a HTTP DELETE request (async).
        /// </summary>
        /// <param name="path">The target path (or resource).</param>
        /// <param name="options">The additional request options.</param>
        /// <param name="configuration">A per-request configuration object. It is assumed that any merge with
        /// GlobalConfiguration has been done before calling this method.</param>
        /// <param name="cancellationToken">Token that enables callers to cancel the request.</param>
        /// <returns>A Task containing ApiResponse</returns>
        public Task<ApiResponse<T>> DeleteAsync<T>(string path, IRequestOptions options, IReadableConfiguration configuration = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            var config = configuration ?? GlobalConfiguration.Instance;
            return ExecAsync<T>(NewRequest(HttpMethod.Delete, path, options, config), config, cancellationToken);
        }

        /// <summary>
        /// Make a HTTP HEAD request (async).
        /// </summary>
        /// <param name="path">The target path (or resource).</param>
        /// <param name="options">The additional request options.</param>
        /// <param name="configuration">A per-request configuration object. It is assumed that any merge with
        /// GlobalConfiguration has been done before calling this method.</param>
        /// <param name="cancellationToken">Token that enables callers to cancel the request.</param>
        /// <returns>A Task containing ApiResponse</returns>
        public Task<ApiResponse<T>> HeadAsync<T>(string path, IRequestOptions options, IReadableConfiguration configuration = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            var config = configuration ?? GlobalConfiguration.Instance;
            return ExecAsync<T>(NewRequest(HttpMethod.Head, path, options, config), config, cancellationToken);
        }

        /// <summary>
        /// Make a HTTP OPTION request (async).
        /// </summary>
        /// <param name="path">The target path (or resource).</param>
        /// <param name="options">The additional request options.</param>
        /// <param name="configuration">A per-request configuration object. It is assumed that any merge with
        /// GlobalConfiguration has been done before calling this method.</param>
        /// <param name="cancellationToken">Token that enables callers to cancel the request.</param>
        /// <returns>A Task containing ApiResponse</returns>
        public Task<ApiResponse<T>> OptionsAsync<T>(string path, IRequestOptions options, IReadableConfiguration configuration = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            var config = configuration ?? GlobalConfiguration.Instance;
            return ExecAsync<T>(NewRequest(HttpMethod.Options, path, options, config), config, cancellationToken);
        }

        /// <summary>
        /// Make a HTTP PATCH request (async).
        /// </summary>
        /// <param name="path">The target path (or resource).</param>
        /// <param name="options">The additional request options.</param>
        /// <param name="configuration">A per-request configuration object. It is assumed that any merge with
        /// GlobalConfiguration has been done before calling this method.</param>
        /// <param name="cancellationToken">Token that enables callers to cancel the request.</param>
        /// <returns>A Task containing ApiResponse</returns>
        public Task<ApiResponse<T>> PatchAsync<T>(string path, IRequestOptions options, IReadableConfiguration configuration = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            var config = configuration ?? GlobalConfiguration.Instance;
            return ExecAsync<T>(NewRequest(HttpMethod.Patch, path, options, config), config, cancellationToken);
        }
        #endregion IAsynchronousClient

        #region ISynchronousClient
        /// <summary>
        /// Make a HTTP GET request (synchronous).
        /// </summary>
        /// <param name="path">The target path (or resource).</param>
        /// <param name="options">The additional request options.</param>
        /// <param name="configuration">A per-request configuration object. It is assumed that any merge with
        /// GlobalConfiguration has been done before calling this method.</param>
        /// <returns>A Task containing ApiResponse</returns>
        public ApiResponse<T> Get<T>(string path, IRequestOptions options, IReadableConfiguration configuration = null)
        {
            var config = configuration ?? GlobalConfiguration.Instance;
            return Exec<T>(NewRequest(HttpMethod.Get, path, options, config), config);
        }

        /// <summary>
        /// Make a HTTP POST request (synchronous).
        /// </summary>
        /// <param name="path">The target path (or resource).</param>
        /// <param name="options">The additional request options.</param>
        /// <param name="configuration">A per-request configuration object. It is assumed that any merge with
        /// GlobalConfiguration has been done before calling this method.</param>
        /// <returns>A Task containing ApiResponse</returns>
        public ApiResponse<T> Post<T>(string path, IRequestOptions options, IReadableConfiguration configuration = null)
        {
            var config = configuration ?? GlobalConfiguration.Instance;
            return Exec<T>(NewRequest(HttpMethod.Post, path, options, config), config);
        }

        /// <summary>
        /// Make a HTTP PUT request (synchronous).
        /// </summary>
        /// <param name="path">The target path (or resource).</param>
        /// <param name="options">The additional request options.</param>
        /// <param name="configuration">A per-request configuration object. It is assumed that any merge with
        /// GlobalConfiguration has been done before calling this method.</param>
        /// <returns>A Task containing ApiResponse</returns>
        public ApiResponse<T> Put<T>(string path, IRequestOptions options, IReadableConfiguration configuration = null)
        {
            var config = configuration ?? GlobalConfiguration.Instance;
            return Exec<T>(NewRequest(HttpMethod.Put, path, options, config), config);
        }

        /// <summary>
        /// Make a HTTP DELETE request (synchronous).
        /// </summary>
        /// <param name="path">The target path (or resource).</param>
        /// <param name="options">The additional request options.</param>
        /// <param name="configuration">A per-request configuration object. It is assumed that any merge with
        /// GlobalConfiguration has been done before calling this method.</param>
        /// <returns>A Task containing ApiResponse</returns>
        public ApiResponse<T> Delete<T>(string path, IRequestOptions options, IReadableConfiguration configuration = null)
        {
            var config = configuration ?? GlobalConfiguration.Instance;
            return Exec<T>(NewRequest(HttpMethod.Delete, path, options, config), config);
        }

        /// <summary>
        /// Make a HTTP HEAD request (synchronous).
        /// </summary>
        /// <param name="path">The target path (or resource).</param>
        /// <param name="options">The additional request options.</param>
        /// <param name="configuration">A per-request configuration object. It is assumed that any merge with
        /// GlobalConfiguration has been done before calling this method.</param>
        /// <returns>A Task containing ApiResponse</returns>
        public ApiResponse<T> Head<T>(string path, IRequestOptions options, IReadableConfiguration configuration = null)
        {
            var config = configuration ?? GlobalConfiguration.Instance;
            return Exec<T>(NewRequest(HttpMethod.Head, path, options, config), config);
        }

        /// <summary>
        /// Make a HTTP OPTION request (synchronous).
        /// </summary>
        /// <param name="path">The target path (or resource).</param>
        /// <param name="options">The additional request options.</param>
        /// <param name="configuration">A per-request configuration object. It is assumed that any merge with
        /// GlobalConfiguration has been done before calling this method.</param>
        /// <returns>A Task containing ApiResponse</returns>
        public ApiResponse<T> Options<T>(string path, IRequestOptions options, IReadableConfiguration configuration = null)
        {
            var config = configuration ?? GlobalConfiguration.Instance;
            return Exec<T>(NewRequest(HttpMethod.Options, path, options, config), config);
        }

        /// <summary>
        /// Make a HTTP PATCH request (synchronous).
        /// </summary>
        /// <param name="path">The target path (or resource).</param>
        /// <param name="options">The additional request options.</param>
        /// <param name="configuration">A per-request configuration object. It is assumed that any merge with
        /// GlobalConfiguration has been done before calling this method.</param>
        /// <returns>A Task containing ApiResponse</returns>
        public ApiResponse<T> Patch<T>(string path, IRequestOptions options, IReadableConfiguration configuration = null)
        {
            var config = configuration ?? GlobalConfiguration.Instance;
            return Exec<T>(NewRequest(HttpMethod.Patch, path, options, config), config);
        }
        #endregion ISynchronousClient
    }

    /// <summary>
    /// Allows RestSharp to Serialize/Deserialize JSON using our custom logic, but only when ContentType is JSON.
    /// </summary>
    internal class CustomJsonCodec : RestSharp.Serializers.ISerializer, IDeserializer
    {
        private readonly IReadableConfiguration _configuration;
        private readonly string _contentType = "application/json";

        private readonly JsonSerializerSettings _serializerSettings = new()
        {
            // OpenAPI generated types generally hide default constructors.
            ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy
                {
                    OverrideSpecifiedNames = false
                }
            }
        };

        public CustomJsonCodec(IReadableConfiguration configuration)
        {
            _configuration = configuration;
        }

        public CustomJsonCodec(JsonSerializerSettings serializerSettings, IReadableConfiguration configuration)
        {
            _serializerSettings = serializerSettings;
            _configuration = configuration;
        }

        /// <summary>
        /// Serialize the object into a JSON string.
        /// </summary>
        /// <param name="obj">Object to be serialized.</param>
        /// <returns>A JSON string.</returns>
        public string Serialize(object obj)
        {
            return obj is AbstractOpenAPISchema schema ? schema.ToJson() : JsonConvert.SerializeObject(obj, _serializerSettings);
        }

        public T Deserialize<T>(IRestResponse response)
        {
            var result = (T)Deserialize(response, typeof(T));
            return result;
        }

        /// <summary>
        /// Deserialize the JSON string into a proper object.
        /// </summary>
        /// <param name="response">The HTTP response.</param>
        /// <param name="type">Object type.</param>
        /// <returns>Object representation of the JSON string.</returns>
        internal object Deserialize(IRestResponse response, Type type)
        {
            if (type == typeof(byte[])) // return byte array
            {
                return response.RawBytes;
            }

            // TODO: ? if (type.IsAssignableFrom(typeof(Stream)))
            if (type == typeof(Stream))
            {
                var bytes = response.RawBytes;
                var filePath = string.IsNullOrEmpty(_configuration.TempFolderPath)
                    ? Path.GetTempPath()
                    : _configuration.TempFolderPath;
                var regex = new Regex(@"Content-Disposition=.*filename=['""]?([^'""\s]+)['""]?$");
                foreach (var header in response.Headers)
                {
                    var match = regex.Match(header.ToString());
                    if (!match.Success) continue;
                    var fileName = filePath + ClientUtils.SanitizeFilename(match.Groups[1].Value.Replace("\"", "").Replace("'", ""));
                    File.WriteAllBytes(fileName, bytes);
                    return new FileStream(fileName, FileMode.Open);
                }
                var stream = new MemoryStream(bytes);
                return stream;
            }

            if (type.Name.StartsWith("System.Nullable`1[[System.DateTime")) // return a datetime object
            {
                return DateTime.Parse(response.Content, null, System.Globalization.DateTimeStyles.RoundtripKind);
            }

            if (type == typeof(string) || type.Name.StartsWith("System.Nullable")) // return primitive type
            {
                return Convert.ChangeType(response.Content, type);
            }

            // at this point, it must be a model (json)
            try
            {
                return JsonConvert.DeserializeObject(response.Content, type, _serializerSettings);
            }
            catch (Exception e)
            {
                throw new ApiException(500, e.Message);
            }
        }

        public string RootElement { get; set; }
        public string Namespace { get; set; }
        public string DateFormat { get; set; }

        public string ContentType
        {
            get => _contentType;
            set => throw new InvalidOperationException("Not allowed to set content type.");
        }
    }
}