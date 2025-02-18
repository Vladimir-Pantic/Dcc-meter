
using Euronet.Audit.Helpers;
using Euronet.Audit.Interfaces;
using Euronet.Mvc.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;

namespace Euronet.Audit
{
	public class AuditLogFilterAttribute : ActionFilterAttribute, IFilterMetadata, IExceptionFilter
	{
		protected IAuditLog AuditLog { get; set; }

		private DateTime _requestTime;
		private DateTime _responseTime;
		private long _resourceId;
		private string _resourceName;
		private string _requestBody;
		private int _statusCode;
		private ActionExecutedContext actionExecutedContext;

        public AuditLogFilterAttribute(IAuditLog auditLog = null)
		{
			AuditLog = auditLog;
		}

		public override Task OnActionExecutionAsync(Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext context, ActionExecutionDelegate next)
		{
			_requestTime = DateTime.Now;

			SetResourceInfo(context);

			return base.OnActionExecutionAsync(context, next);
		}

		public override void OnActionExecuted(Microsoft.AspNetCore.Mvc.Filters.ActionExecutedContext context)
		{
			base.OnActionExecuted(context);

			_responseTime = DateTime.Now;

			//Exception handling
			Exception exception = context.GetException();

			if (exception == null)
			{
				_statusCode = StatusCodeHelper.GetStatusCode(context.Result);

                context.Audit(AuditLog, _resourceId, _resourceName, _requestTime, _responseTime, exception, _requestBody, _statusCode);
			}
			else
				actionExecutedContext = context;
		}

		public override void OnActionExecuting(Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext context)
		{
			base.OnActionExecuting(context);
		}

		private string SerializeObject(object o)
		{
			string str = "{}";

			try
			{
				string newtonsoftConvert = Newtonsoft.Json.JsonConvert.SerializeObject(o);
				string systemConvert = JsonSerializer.Serialize(o);
				//sometimes Newtonsoft serilizer ignore objects inside objects
				str = newtonsoftConvert.Length >= systemConvert.Length ? newtonsoftConvert : systemConvert;
			}
			catch
			{

			}
			return str;
		}

		public void SetResourceInfo(ActionExecutingContext context)
		{
			if (context == null)
			{
				return;
			}

			long id = 0;
			string name = String.Empty;

			string idPropertyName = "id";
			string namePropertyName = "name";

			_requestBody = SerializeObject(context.ActionArguments);

			/*
			If method contains resource atribute, then we will use its metadata for id and name property names.
			*/
			var controllerActionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;

			if (controllerActionDescriptor != null)
			{
				MethodInfo methodInfo = controllerActionDescriptor.MethodInfo;

				if (methodInfo != null)
				{
					ResourceAttribute resourceAttribute = methodInfo.GetCustomAttribute<ResourceAttribute>();

					if (resourceAttribute != null && !String.IsNullOrEmpty(resourceAttribute.ResourceIdPropertyName))
					{
						idPropertyName = resourceAttribute.ResourceIdPropertyName;
					}

					if (resourceAttribute != null && !String.IsNullOrEmpty(resourceAttribute.ResourceNamePropertyName))
					{
						namePropertyName = resourceAttribute.ResourceNamePropertyName;
					}
				}
			}

			/*
			Search through action arguments in order to find arguments with defined id and name property names.
			*/

			bool idFound = false;
			bool nameFound = false;

			foreach (var keyValuePair in context.ActionArguments)
			{
				if (idFound && nameFound)
				{
					break;
				}

				//Check if there is an action argument with name "id"
				if (!idFound)
				{
					if (keyValuePair.Key.ToLower() == idPropertyName.ToLower())
					{
						object o = context.ActionArguments[idPropertyName];

						if (o != null)
						{
							idFound = long.TryParse(o.ToString(), out id);
						}
					}
				}

				//Check if there is an action argument with name "name"
				if (!nameFound)
				{
					if (keyValuePair.Key.ToLower() == namePropertyName.ToLower())
					{
						object o = context.ActionArguments[namePropertyName];

						if (o != null)
						{
							nameFound = long.TryParse(o.ToString(), out id);
						}
					}
				}

				//Check properties of action argument
				object value = keyValuePair.Value;

				if (value != null)
				{
					Type type = value.GetType();

					if (!idFound)
					{
						PropertyInfo propertyInfo = type.GetProperty(idPropertyName);

						if (propertyInfo != null)
						{
							object idValue = propertyInfo.GetValue(value);

							if (idValue != null)
							{
								idFound = long.TryParse(idValue.ToString(), out id);
							}
						}
					}

					if (!nameFound)
					{
						PropertyInfo propertyInfo = type.GetProperty(namePropertyName);

						if (propertyInfo != null)
						{
							object nameValue = propertyInfo.GetValue(value);

							if (nameValue != null)
							{
								name = nameValue.ToString();

								nameFound = true;
							}
						}
					}
				}
			}

			_resourceId = id;
			_resourceName = name;
		}

        public void OnException(ExceptionContext context)
        {

            var exception = context.Exception;

			ExceptionModel exceptionModel = new ExceptionModel
            {
                Message = context.Exception.ToString(),
                Severity = Severity.Error
            };

			exceptionModel.Code = exception switch
			{
				InvalidOperationException _ => _statusCode = 400,
				UnauthorizedAccessException _ => _statusCode = 401,
				KeyNotFoundException _ => _statusCode = 404,
				//ResourceNotFoundException _ => new ObjectResult("The requested resource was not found.") { StatusCode = 404 },
				_ => _statusCode = 500
			};

            //todo exceptionModel dodati u Audit
            context.Result = new Microsoft.AspNetCore.Mvc.JsonResult(exceptionModel) { StatusCode = _statusCode};
			actionExecutedContext.Audit(AuditLog, _resourceId, _resourceName, _requestTime, _responseTime, exception, _requestBody, _statusCode);

        }

		private class ExceptionModel
		{
			public string Message { get; set; }
			public int Code { get; set; }
			public Severity Severity { get; set; }
			//public string Source { get; set; }
		}
	}
}
