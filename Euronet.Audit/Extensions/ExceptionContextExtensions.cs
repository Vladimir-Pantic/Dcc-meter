
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
	public static class ExceptionContextExtensions
	{
		public static void Audit(this Microsoft.AspNetCore.Mvc.Filters.ExceptionContext context,
			IAuditLog auditLog)
		{
			FilterContextExtensions.Audit(context, auditLog, 0, null, DateTime.Now, DateTime.Now, context?.Exception, context?.Result, "", context.Result.GetStatusCode());
		}
	}
}
