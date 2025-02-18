
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using Newtonsoft.Json;
using Euronet.Audit.Interfaces;

namespace Microsoft.AspNetCore.Mvc.Filters
{
	public static class ActionExecutedContextExtensions
	{
		public static void Audit(this ActionExecutedContext context, 
			IAuditLog auditLog,
			long resourceId, string resourceName,
			DateTime? requestTime, DateTime responseTime,
			Exception exception, string requestBody, int statusCode)
		{
			FilterContextExtensions.Audit(context, auditLog, resourceId, resourceName, requestTime, responseTime, exception, context?.Result, requestBody, statusCode);
		}
	}
}
