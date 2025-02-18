using System;

namespace Euronet.Audit
{
	public class ResourceAttribute : Attribute
	{
		public long ResourceTypeId { get; set; }

		public string ResourceTypeName { get; set; }

		public string ResourceIdPropertyName { get; set; }

		public string ResourceNamePropertyName { get; set; }
	}
}
