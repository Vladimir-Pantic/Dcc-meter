using System;

namespace Microsoft.AspNetCore.Mvc.Filters
{
	public static class ActionExecutedContextExtensions
	{
		public static Exception GetException(this ActionExecutedContext context)
		{
			if (context == null)
			{
				return null;
			}

			ObjectResult objectResult = context.Result as ObjectResult;

			if (objectResult != null && objectResult.IsNotOk())
			{
				return objectResult.Value as Exception;
			}
			else
			{
				return context.Exception;
			}
		}
	}
}
