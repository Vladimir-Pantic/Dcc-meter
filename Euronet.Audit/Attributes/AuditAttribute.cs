using System;

namespace Euronet.Audit
{
	public class AuditAttribute : Attribute
	{
		public AuditAttribute(string actionName = null)
		{
			ActionName = actionName;
		}

		public string ActionName { get; set; }

		public long ResourceTypeId { get; set; }

		public string ResourceTypeName { get; set; }

		public string ResourceIdPropertyName { get; set; }

		public string ResourceNamePropertyName { get; set; }
	}
}
