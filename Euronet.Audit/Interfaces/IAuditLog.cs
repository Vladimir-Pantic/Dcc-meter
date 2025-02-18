using System;

namespace Euronet.Audit.Interfaces
{
	/// <summary>
	/// Used to register audit information. 
	/// </summary>
	public interface IAuditLog
	{
		void Log(string message, AuditLogContent options);

		void Log(Exception exception, string message, AuditLogContent options);

		void Log(AuditLogSeverity severity, string message, AuditLogContent options);
	}
}
