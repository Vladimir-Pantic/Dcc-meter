using System;

namespace Microsoft.AspNetCore.Http
{
    /// <summary>
    /// HttpRequest extensions methods.
    /// </summary>
    public static class HttpRequestExtensions
    {
        /// <summary>
        /// Get versioned enndpoint prefix for the request.
        /// </summary>
        /// <param name="request">HttpRequest.</param>
        /// <param name="includeScheme">Include scheme prefix if true.</param>
        /// <returns>string</returns>
        public static string GetVersionedPrefix(this HttpRequest request, bool includeScheme = true, string apiSuffix = "api/v1")
        {
            var scheme = includeScheme ? $"{request.Scheme}://" : String.Empty;

            var baseurl = request.Host.Value;

            apiSuffix = apiSuffix.IsNotNullOrEmpty() ? $"/{apiSuffix}" : String.Empty;

            var versionUrl = $"{scheme}{baseurl}{apiSuffix}";

            return versionUrl;
        }
    }
}