namespace Euronet.Audit.Settings
{
	public class AuditSettings
	{
		public AuditSettings()
		{
			DisableAudit = false;
		}

		public bool DisableAudit { get; set; }

		public AuditLogSeverity Severity { get; set; }
	}
}
