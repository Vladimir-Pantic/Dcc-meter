
using Euronet.Audit;
using Euronet.Audit.Helpers;
using Euronet.Audit.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Claims;

namespace Microsoft.AspNetCore.Mvc.Filters
{
	public static class FilterContextExtensions
	{
		public static void Audit(this FilterContext context,
			IAuditLog auditLog,
			long resourceId, string resourceName,
			DateTime? requestTime, DateTime responseTime,
			Exception exception, IActionResult result, 
			string requestBody, int statusCode)
		{
			if (context != null && auditLog != null)
			{
				var controllerActionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;

				if (controllerActionDescriptor == null)
				{
					throw new ArgumentNullException("controllerActionDescriptor");
				}

				var methodInfo = controllerActionDescriptor.MethodInfo;

				if (methodInfo != null)
				{
					//Check if method has an AuditAttribute...
					var auditAttribute = methodInfo.GetCustomAttribute<AuditAttribute>();

					if (auditAttribute == null)
					{
						//...or get it from Controller.
						auditAttribute = controllerActionDescriptor.ControllerTypeInfo.GetCustomAttribute<AuditAttribute>();
					}

					//Audit only if appropriate attribut is set                            
					if (auditAttribute != null)
					{
						var options = new AuditLogContent();

						//TODO check where to generate RequestId.
						options.RequestId = context.HttpContext.Request.GetRequestId();

						options.RequestUrl = RequestHelper.FormatRequestUrl(Microsoft.AspNetCore.Http.Extensions.UriHelper.GetEncodedUrl(context.HttpContext.Request));

						//read from request
						var content = context.HttpContext.Request.GetRequestContentAsync();

						//if (content != null && String.IsNullOrEmpty(content.Result) == false)
						//{
						//	options.RequestContent = content.Result;
						//}

						options.RequestContent = requestBody;

						options.RequestTimeStamp = requestTime;

						options.RequestType = context.HttpContext.Request.Method;

						var responseMessage = exception?.Message;
						//maybe better place for request & response is eventlog?
						var responseBody = result.GetResponseContent();

						if(responseBody != null && responseBody.StartsWith("Error"))
                        {
							exception = new Exception(responseBody);
                        }

						options.ResponseContent = responseBody ?? responseMessage ?? "";

						options.ResponseTimeStamp = DateTime.Now;

						options.StatusCode = statusCode == 0 ? result.GetStatusCode() : statusCode;

						var statusCode1 = StatusCodeHelper.GetStatusCode(result);

						//User
						var user = context.HttpContext.User;

						options.UserId = user.GetUserId();
						options.UserName = user.GetUserName();

						//UserAgent
						var userAgent = context.HttpContext.Request.GetUserAgent();

						if (userAgent != null)
						{
							if (userAgent.OS != null)
							{
								options.UserOS = userAgent.OS.Name;
								options.UserOSVersion = userAgent.OS.Version;
							}

							if (userAgent.Browser != null)
							{
								options.UserBrowser = userAgent.Browser.Name;
								options.UserBrowserVersion = userAgent.Browser.Version;
							}
						}

						//Action
						string actionName = auditAttribute.ActionName;

						options.ActionName = actionName;

						if (String.IsNullOrEmpty(actionName))
						{
							actionName = controllerActionDescriptor.GetActionName();

							options.ActionName = actionName;
						}

						//TODO check if if it reasonalble to have IActionStore interface wich will be responsible to get id by action name.
						options.ActionId = 0;

						//Try to read from parametars
						options.ResourceId = resourceId;
						options.ResourceName = resourceName;

						//Check if method applies to specific resource,...
						ResourceAttribute resourceAttribute = methodInfo.GetCustomAttribute<ResourceAttribute>();

						if (resourceAttribute == null)
						{
							//...or get resource descriptor from controller.
							resourceAttribute = controllerActionDescriptor.ControllerTypeInfo.GetCustomAttribute<ResourceAttribute>();
						}

						if (resourceAttribute != null)
						{
							options.ResourceTypeId = resourceAttribute.ResourceTypeId;
							options.ResourceTypeName = resourceAttribute.ResourceTypeName;
						}

						if (string.IsNullOrEmpty(options.ResourceTypeName))
						{
							options.ResourceTypeName = controllerActionDescriptor.ControllerName;
						}

						string message = context.ActionDescriptor.DisplayName;

						if (options.RequestTimeStamp != null && options.ResponseTimeStamp != null)
						{
							try
							{
								options.Duration = Convert.ToInt64(options.ResponseTimeStamp.Value.Subtract(options.RequestTimeStamp.Value).TotalMilliseconds);
							}
							catch{}
						}

						if (exception != null)
						{
							auditLog.Log(exception, message, options);
						}
						else
						{
							auditLog.Log(message, options);
						}
					}
				}
			}
		}
	}
}
