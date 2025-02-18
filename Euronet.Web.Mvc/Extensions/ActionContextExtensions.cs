using Euronet.Exceptions;
using Euronet.Web;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;


namespace Euronet.Extensions
{
	public static class ActionContextExtensions
	{
		public static BadRequestObjectResult GetApiProblemResult(this ActionContext actionContext, ErrorDetails errorDetails = null)
		{
			var result = new ApiProblem();

			var modelStateDictionary = actionContext.ModelState;
			var httpContext = actionContext.HttpContext;

			result.Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1";
			result.Instance = httpContext.Request.Path.ToString();
			result.Status = (int)HttpStatusCode.BadRequest;
			result.Title = "Bad Request";
			result.Detail = "One or more validation errors occured.";

			try
			{
				var errors = new List<ErrorDetails>();

				foreach (var key in modelStateDictionary.Keys)
				{
					foreach (var error in modelStateDictionary[key].Errors)
					{
						string message = error.ErrorMessage ?? (error.Exception != null ? error.Exception.Message : null);

						ErrorDetails ed = JsonConvert.DeserializeObject<ErrorDetails>(message);

						result.Errors.Add(ed);
					}
				}
			}
			catch
			{

			}

			return new BadRequestObjectResult(result);
		}
	}
}
