
using Serilog;
using Serilog.Context;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;
using System;

using Euronet.Audit.Settings;
using Euronet.Audit.Serilog;

namespace Euronet.Audit.SqlServer
{
	public class SqlServerSerilogAuditLog : SerilogAuditLog
	{
		private static readonly string AUDIT_LOG_SCHEMA_NAME = "dbo";
		private static readonly string AUDIT_LOG_TABLE_NAME = "AuditLog";

		private readonly AuditDbSettings _auditSettings;
		private readonly GlobalEnrichOptions _globalEnrichOptions;
		private readonly AuditLogColumnOptions _columnOptions;

		public SqlServerSerilogAuditLog(
			AuditDbSettings auditSettings,
			GlobalEnrichOptions globalEnrichOptions,
			AuditLogColumnOptions columnOptions) :base()
		{
			_auditSettings = auditSettings;
			_columnOptions = columnOptions;
			_globalEnrichOptions = globalEnrichOptions;
		}

		protected override bool EncodeUrl() => false;

		protected override ILogger CreateLogger()
		{
			return new LoggerConfiguration()
				.MinimumLevel.Is((LogEventLevel)_auditSettings.Severity)
				.WriteTo.MSSqlServer(
					connectionString: _auditSettings.ConnectionString,
					sinkOptions: new MSSqlServerSinkOptions()
					{
						SchemaName = _auditSettings.SchemaName.IfNullOrEmpty(AUDIT_LOG_SCHEMA_NAME),
						TableName = _auditSettings.TableName.IfNullOrEmpty(AUDIT_LOG_TABLE_NAME),
						
					},
					columnOptions: (_columnOptions ?? new AuditLogColumnOptions()).GetColumnOptions())
				//.Enrich(_globalEnrichOptions)
				.Enrich.FromLogContext()
				.CreateLogger();
		}
	}
}
