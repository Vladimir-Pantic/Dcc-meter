using Euronet.Audit.Settings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Euronet.Audit.Settings
{
	public class AuditDbSettings: AuditSettings
	{
		public string ConnectionString { get; set; }

		public string TableName { get; set; }

		public string SchemaName { get; set; }
	}
}
