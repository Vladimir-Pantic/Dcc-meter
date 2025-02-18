namespace Microsoft.AspNetCore.Mvc
{
	public static class StatusCodeExtensions
	{
		public static bool IsNotOk(this ObjectResult objectResult)
		{
			if (objectResult != null && objectResult.StatusCode.HasValue)
			{
				int statusCode = objectResult.StatusCode.Value;

				return statusCode >= 400;
			}

			return false;
		}

		public static int GetStatusCode(this IActionResult actionResult)
		{
			if (actionResult == null)
			{
				return 0;
			}

			ObjectResult objectResult = actionResult as ObjectResult;

			if (objectResult == null || objectResult.StatusCode == null)
			{
				return 0;
			}

			return objectResult.StatusCode.Value;
		}
	}
}
