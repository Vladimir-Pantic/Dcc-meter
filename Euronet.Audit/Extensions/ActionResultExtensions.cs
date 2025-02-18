using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.AspNetCore.Mvc
{
	public static class ActionResultExtensions
	{
		public static string GetResponseContent(this IActionResult actionResult)
		{
			if (actionResult == null)
			{
				return null;
			}

			string responseContent = String.Empty;

			try
			{
				if (actionResult is ObjectResult objectResult)
				{
					responseContent = JsonConvert.SerializeObject(objectResult.Value, Formatting.Indented, new JsonSerializerSettings() { ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore });
				}
				else if (actionResult is ViewResult viewResult)
				{
					responseContent = JsonConvert.SerializeObject(viewResult.Model, Formatting.Indented, new JsonSerializerSettings() { ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore });
				}
			}
			catch (Exception ex)
			{
				responseContent = ex.Message;
			}

			return responseContent;
		}
	}
}
