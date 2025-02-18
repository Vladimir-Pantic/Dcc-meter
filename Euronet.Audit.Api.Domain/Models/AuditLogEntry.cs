using System;
using System.Runtime.Serialization;

namespace Euronet.Audit.Api.Domain.Models
{
	[DataContract(Name = "audit-log-entry")]
	public class AuditLogEntry
	{
		/// <summary>
		/// Id
		/// </summary>
		[DataMember(Name = "id")]
		public long Id { get; set; }

		/// <summary>
		/// Action Id
		/// </summary>
		[DataMember(Name = "action-id")]
		public long? ActionId { get; set; }

		/// <summary>
		/// Action Name
		/// </summary>
		[DataMember(Name = "action-name")]
		public string ActionName { get; set; }

		/// <summary>
		/// Application Id
		/// </summary>
		[DataMember(Name = "application-id")]
		public int? ApplicationId { get; set; }

		/// <summary>
		/// Application Name
		/// </summary>
		[DataMember(Name = "application-name")]
		public string ApplicationName { get; set; }

		/// <summary>
		/// Application Version
		/// </summary>
		[DataMember(Name = "application-version")]
		public string ApplicationVersion { get; set; }

		/// <summary>
		/// Environment User Name
		/// </summary>
		[DataMember(Name = "environment-user-name")]
		public string EnvironmentUserName { get; set; }

		/// <summary>
		/// Exception
		/// </summary>
		[DataMember(Name = "exception")]
		public string Exception { get; set; }

		/// <summary>
		/// Level
		/// </summary>
		//[DataMember(Name = "severity-level")]
		//public AuditLogEntrySeverityLevel? SeverityLevel { get; set; }

		/// <summary>
		/// Machine Name
		/// </summary>
		[DataMember(Name = "machine-name")]
		public string MachineName { get; set; }

		/// <summary>
		/// Message
		/// </summary>
		[DataMember(Name = "message")]
		public string Message { get; set; }

		/// <summary>
		/// Properties
		/// </summary>
		//[DataMember(Name = "properties")]
		//public AuditLogEntryPropertyList Properties { get; set; }

		/// <summary>
		/// Request Content
		/// </summary>
		[DataMember(Name = "request-content")]
		public string RequestContent { get; set; }

		/// <summary>
		/// Request Id
		/// </summary>
		[DataMember(Name = "request-id")]
		public string RequestId { get; set; }

		/// <summary>
		/// Request Time Stamp
		/// </summary>
		[DataMember(Name = "request-time-stamp")]
		public DateTime? RequestTimeStamp { get; set; }

		/// <summary>
		/// Request Type
		/// </summary>
		[DataMember(Name = "request-type")]
		public string RequestType { get; set; }

		/// <summary>
		/// Request Url
		/// </summary>
		[DataMember(Name = "request-url")]
		public string RequestUrl { get; set; }

		/// <summary>
		/// Resource Id
		/// </summary>
		[DataMember(Name = "resource-id")]
		public long? ResourceId { get; set; }

		/// <summary>
		/// Resource Name
		/// </summary>
		[DataMember(Name = "resource-name")]
		public string ResourceName { get; set; }

		/// <summary>
		/// Resource Type Id
		/// </summary>
		[DataMember(Name = "resource-type-id")]
		public long? ResourceTypeId { get; set; }

		/// <summary>
		/// Resource Type Name
		/// </summary>
		[DataMember(Name = "resource-type-name")]
		public string ResourceTypeName { get; set; }

		/// <summary>
		/// Response Content
		/// </summary>
		[DataMember(Name = "response-content")]
		public string ResponseContent { get; set; }

		/// <summary>
		/// Response Time Stamp
		/// </summary>
		[DataMember(Name = "response-time-stamp")]
		public DateTime? ResponseTimeStamp { get; set; }

		/// <summary>
		/// Status Code
		/// </summary>
		[DataMember(Name = "status-code")]
		public int? StatusCode { get; set; }

		/// <summary>
		/// Time Stamp
		/// </summary>
		[DataMember(Name = "time-stamp")]
		public DateTime TimeStamp { get; set; }

		/// <summary>
		/// User Browser
		/// </summary>
		[DataMember(Name = "user-browser")]
		public string UserBrowser { get; set; }

		/// <summary>
		/// User Browser Version
		/// </summary>
		[DataMember(Name = "user-browser-version")]
		public string UserBrowserVersion { get; set; }

		/// <summary>
		/// User Id
		/// </summary>
		[DataMember(Name = "user-id")]
		public long? UserId { get; set; }

		/// <summary>
		/// User Name
		/// </summary>
		[DataMember(Name = "user-name")]
		public string UserName { get; set; }

		/// <summary>
		/// User Os
		/// </summary>
		[DataMember(Name = "user-o-s")]
		public string UserOs { get; set; }

		/// <summary>
		/// User Osversion
		/// </summary>
		[DataMember(Name = "user-o-s-version")]
		public string UserOsversion { get; set; }
	}
}
