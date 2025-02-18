using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Euronet.Validation.Models
{
	/// <summary>
	/// Used to extend ProblemDetails.
	/// </summary>
	public class ErrorDetails
	{
		public ErrorDetails()
		{
			Severity = Severity.Error;
		}

		public ErrorDetails(string message): this()
		{
			Message = message;
		}

		public ErrorDetails(string message, int code) : this(message)
		{
			Code = code;
		}
		public ErrorDetails(int code) : this()
		{
			Code = code;
		}

		public ErrorDetails(string message, int code, Severity severity) : this(message, code)
		{
			Severity = severity;
		}

		public ErrorDetails(string message, int code, Severity severity, IDictionary<string, object> parameters) : this(message, code, severity)
		{
			Parameters = parameters;
		}

		[DataMember(Name = "message")]
		public string Message { get; set; }
		[DataMember(Name = "code")]
		public int? Code { get; set; }
		[DataMember(Name = "severity")]
		public Severity Severity { get; set; }
		[DataMember(Name = "source")]
		public string Source { get; set; }
		[DataMember(Name = "parameters")]
		public IDictionary<string, object> Parameters { get; set; }
	}
}
