using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Euronet.Validation.Models
{
	public class ValidationProblem : ValidationResult
	{
		public ValidationProblem(string message, int? code = null, Severity severity = Severity.Error, string source = null, IDictionary<string, object> parameters = null)
			: base(GetErrorMessage(message, code, severity, source, parameters))
		{
		}

		private static string GetErrorMessage(string message, int? code, Severity severity, string source, IDictionary<string, object> parameters)
		{
			var validationDetails = new ErrorDetails()
			{
				Message = message,
				Code = code ?? 400,
				Severity = severity,
				Source = source,
				Parameters = parameters
			};

			string result = null;

			try
			{
				result = JsonConvert.SerializeObject(validationDetails);
			}
			catch
			{
			
			}

			return result;
		}
	}
}
