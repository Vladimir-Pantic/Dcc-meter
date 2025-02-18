using System;

namespace Microsoft.AspNetCore.Mvc.Controllers
{
	public static class ControllerActionDescriptorExtensions
	{
		public static string GetActionName(this ControllerActionDescriptor action)
		{
			if (action == null)
			{
				return String.Empty;
			}

			string actionName = action.DisplayName;

			if (action != null)
			{
				actionName = $"{action.ControllerName}.{action.ActionName}";
			}

			return actionName;
		}
	}
}
