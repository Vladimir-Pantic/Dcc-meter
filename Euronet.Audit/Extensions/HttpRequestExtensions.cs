
using Euronet.Audit;
using Euronet.System;
using Microsoft.Extensions.Primitives;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Http
{
    public static class HttpRequestExtensions
    {
        public static string GetHeader(this HttpRequest httpRequest, string key)
        {
            if (httpRequest == null || httpRequest.Headers == null)
            {
                return null;
            }

            StringValues value = StringValues.Empty;

            httpRequest.Headers.TryGetValue(key, out value);

            return value;
        }

        public static string GetAccessUserName(this HttpRequest httpRequest)
        {
            return GetHeader(httpRequest, HeaderKeys.AccessUserName);
        }

        public static long? GetAccessUserId(this HttpRequest httpRequest)
        {
            string accessUserId = GetHeader(httpRequest, HeaderKeys.AccessUserId);

            long? id = null;

            if (!accessUserId.IsNullOrEmpty())
            {
                if (long.TryParse(accessUserId, out long result))
                {
                    id = result;
                }
            }

            return id;
        }

        public static string GetAccessOrganizationUnitCode(this HttpRequest httpRequest)
        {
            return GetHeader(httpRequest, HeaderKeys.AccessOrganizationUnitCode);
        }

        /// <summary>
        /// Get versioned enndpoint prefix for the request.
        /// </summary>
        /// <param name="request">HttpRequest.</param>
        /// <param name="includeScheme">Include scheme prefix if true.</param>
        /// <returns>string</returns>
        public static string GetRoutePrefix(this HttpRequest request, bool includeScheme = true, string apiPrefix = "api", string version = "v1")
        {
            var scheme = includeScheme ? $"{request.Scheme}://" : String.Empty;

            var api = apiPrefix.IsNullOrWhiteSpace() ? String.Empty : $"/{apiPrefix}";

            var ver = version.IsNullOrWhiteSpace() ? String.Empty : $"/{version}";

            var baseurl = request.Host.Value;

            return $"{scheme}{baseurl}{api}{ver}";
        }

        public static async Task<string> GetRequestContentAsync(this HttpRequest request, bool removeRequestVerificationToken = true)
        {
            string requestContent = String.Empty;

            if (request.ContentLength != null)
            {
                //request.EnableRewind(); -> asp net core 3.0
                HttpRequestRewindExtensions.EnableBuffering(request);

                using (StreamReader reader = new StreamReader(request.Body, Encoding.UTF8, true, 1024, true))
                {
                    request.Body.Seek(0, SeekOrigin.Begin);

                    requestContent = await reader.ReadToEndAsync();

                    request.Body.Seek(0, SeekOrigin.Begin);
                }
            }

            if (removeRequestVerificationToken)
            {
                requestContent = RemoveRequestVerificationToken(requestContent);
            }

            return FormatRequestContent(requestContent);
        }

        private static string FormatRequestContent(string requestContent)
        {
            return requestContent.Replace("%5B", "[").Replace("%5D", "]").Replace("%3A", ":");
        }

        private static string RemoveRequestVerificationToken(string requestContent)
        {
            if (String.IsNullOrEmpty(requestContent))
            {
                return requestContent;
            }

            int i = requestContent.IndexOf("&__RequestVerificationToken=");

            if (i < 0)
            {
                return requestContent;
            }

            int next_i = requestContent.IndexOf('&', i + 1);

            if (next_i < 0)
            {
                return requestContent.Remove(i);
            }
            else
            {
                return requestContent.Remove(i, next_i - i);
            }
        }

        public static UserAgent GetUserAgent(this HttpRequest request)
        {
            if (request == null)
            {
                return null;
            }

            if (!request.Headers.ContainsKey("User-Agent"))
            {
                return null;
            }

            string userAgent = request.Headers["User-Agent"];

            UserAgent ua = new UserAgent(userAgent);

            return ua;
        }

        public static string GetRequestId(this HttpRequest request)
        {
            if (request == null)
            {
                return Guid.NewGuid().ToString();
            }

            if (request.Headers.ContainsKey("RequestId"))
            {
                return request.Headers["RequestId"];
            }

            string requestId = Guid.NewGuid().ToString();

            request.Headers.Add("RequestId", requestId);

            return requestId;
        }
    }
}
