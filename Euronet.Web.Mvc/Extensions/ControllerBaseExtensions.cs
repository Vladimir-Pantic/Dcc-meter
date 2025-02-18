
using Euronet.Web;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Microsoft.AspNetCore.Mvc
{
	public static class ControllerBaseExtensions
	{
		/// <summary>
		/// Creates a Microsoft.AspNetCore.Mvc.ObjectResult object that produces a Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError response.
		/// </summary>
		/// <param name="controller">ControllerBase</param>
		/// <returns>ObjectResult</returns>
		public static StatusCodeResult InternalServerError(this ControllerBase controller)
		{
			return controller.StatusCode(StatusCodes.Status500InternalServerError);
		}

		/// <summary>
		/// Creates a Microsoft.AspNetCore.Mvc.ObjectResult object that produces a Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError response.
		/// </summary>
		/// <param name="controller">ControllerBase</param>
		/// <param name="value"></param>
		/// <returns>ObjectResult</returns>
		public static ObjectResult InternalServerError(this ControllerBase controller, object value)
		{
			return controller.StatusCode(StatusCodes.Status500InternalServerError, value);
		}

		/// <summary>
		/// Creates a Microsoft.AspNetCore.Mvc.ObjectResult object that produces a Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError response.
		/// </summary>
		/// <param name="controller">ControllerBase</param>
		/// <returns>ObjectResult</returns>
		/// <param name="code">Error code.</param>
		/// <param name="message">Error message.</param>
		/// <param name="source">Error source.</param>
		/// <returns></returns>
		public static ObjectResult InternalServerError(this ControllerBase controller, int code, string message = null, string source = null)
		{
			return controller.StatusCode(StatusCodes.Status500InternalServerError, new ApiProblem(message, code)
			{
				Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
				Title = "Internal Server Error",
				Status = StatusCodes.Status500InternalServerError,
				Instance = GetInstance(controller, source)
			});
		}

		/// <summary>
		/// Creates a Microsoft.AspNetCore.Mvc.ObjectResult object that produces a Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest response.
		/// </summary>
		/// <param name="controller">ControllerBase</param>
		/// <returns>ObjectResult</returns>
		/// <param name="code">Error code.</param>
		/// <param name="message">Error message.</param>
		/// <param name="source">Error source.</param>
		/// <returns></returns>
		public static ObjectResult BadRequest(this ControllerBase controller, int code, string message = null, string source = null)
		{
			return controller.StatusCode(StatusCodes.Status400BadRequest, new ApiProblem(message, code)
			{
				Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
				Title = "Bad Request",
				Status = StatusCodes.Status400BadRequest,
				Instance = GetInstance(controller, source)
			}); 
		}

		/// <summary>
		/// Creates a Microsoft.AspNetCore.Mvc.ObjectResult object that produces a Microsoft.AspNetCore.Http.StatusCodes.Status404NotFound response.
		/// </summary>
		/// <param name="controller">ControllerBase</param>
		/// <returns>ObjectResult</returns>
		/// <param name="code">Error code.</param>
		/// <param name="message">Error message.</param>
		/// <param name="source">Error source.</param>
		/// <returns></returns>
		public static ObjectResult NotFound(this ControllerBase controller, int code, string message = null, string source = null)
		{
			return controller.StatusCode(StatusCodes.Status404NotFound, new ApiProblem(message, code)
			{
				Type = "https://tools.ietf.org/html/rfc7231#section-6.5.4",
				Title = "Not Found",
				Status = StatusCodes.Status404NotFound,
				Instance = GetInstance(controller, source)
			});
		}

		/// <summary>
		/// Creates a Microsoft.AspNetCore.Mvc.ObjectResult object that produces a Microsoft.AspNetCore.Http.StatusCodes.Status409Conflict response.
		/// </summary>
		/// <param name="controller">ControllerBase</param>
		/// <returns>ObjectResult</returns>
		/// <param name="code">Error code.</param>
		/// <param name="message">Error message.</param>
		/// <param name="source">Error source.</param>
		/// <returns></returns>
		public static ObjectResult Conflict(this ControllerBase controller, int code, string message = null, string source = null)
		{
			return controller.Conflict(new ApiProblem(message, code)
			{
				Type = "https://tools.ietf.org/html/rfc7231#section-6.5.8",
				Title = "Confilict",
				Status = StatusCodes.Status409Conflict,
				Instance = GetInstance(controller, source)
			});
		}

		private static string GetInstance(ControllerBase controller, string source)
		{
			string instance = source;

			if (instance == null)
			{
				instance = controller.HttpContext?.Request?.Path;
			}

			if (instance == null)
			{
				instance = controller.GetType().FullName;
			}

			return instance;
		}
	}
}
