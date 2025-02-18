
using System;
using System.Collections.Generic;

namespace Euronet.Audit
{
	public class AuditLogContent
	{
		public long? UserId { get; set; }
		public string UserName { get; set; }
		public string UserOS { get; set; }
		public string UserOSVersion { get; set; }
		public string UserBrowser { get; set; }
		public string UserBrowserVersion { get; set; }
		public long? ActionId { get; set; }
		public string ActionName { get; set; }
		public long? ResourceTypeId { get; set; }
		public string ResourceTypeName { get; set; }
		public long? ResourceId { get; set; }
		public string ResourceName { get; set; }
		public string RequestId { get; set; }
		public string RequestUrl { get; set; }
		public string RequestType { get; set; }
		public string RequestContent { get; set; }
		public DateTime? RequestTimeStamp { get; set; }
		public string ResponseContent { get; set; }
		public DateTime? ResponseTimeStamp { get; set; }
		public int? StatusCode { get; set; }
		public long? Duration { get; set; }
	}
}
