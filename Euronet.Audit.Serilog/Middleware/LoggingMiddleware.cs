using Microsoft.AspNetCore.Http;
using Serilog;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Euronet.Serilog.Middleware
{
	/// <summary>
	/// Logging middleware.
	/// </summary>
	public class LoggingMiddleware
	{
		private readonly RequestDelegate _next;

		public LoggingMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public Task InvokeAsync(HttpContext context)
		{
			Log.Debug($"Request: ");
			Log.Debug($"	Url: {Microsoft.AspNetCore.Http.Extensions.UriHelper.GetEncodedUrl(context.Request)}");
			Log.Debug($"	Method: {context.Request.Method}");

			var content = GetRequestContent(context.Request);

			if (content != null && String.IsNullOrEmpty(content.Result) == false)
			{
				Log.Verbose($"	Content: {content.Result}");
			}

			return _next(context);
		}

		private async Task<string> GetRequestContent(HttpRequest request)
		{
			string requestContent = String.Empty;

			try
			{
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
			}
			catch (Exception ex)
			{
				Log.Error(ex.ToString());
			}

			return RemoveRequestVerificationToken(requestContent);
		}

		private string RemoveRequestVerificationToken(string requestContent)
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
	}
}
