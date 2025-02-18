using System;
using Euronet.Audit.Settings;
using Euronet.Audit.SqlServer;
using Euronet.Audit.Interfaces;
using Euronet.Audit.Serilog;

namespace Microsoft.Extensions.DependencyInjection
{
	public static class SqlServerSerilogAuditServiceCollectionExtensions
	{
		public static IServiceCollection AddSqlServerSerilogAudit(this IServiceCollection services, 
			AuditDbSettings settings, 
			GlobalEnrichOptions globalEnrichOptions,
			AuditLogColumnOptions auditLogColumnOptions = null)
		{
			services.AddSingleton<AuditDbSettings>(new AuditDbSettings()
			{
				ConnectionString = settings.ConnectionString,
				TableName = settings.TableName,
				SchemaName = settings.SchemaName,
				Severity = settings.Severity
			});

			services.AddSingleton<GlobalEnrichOptions>(globalEnrichOptions);

			services.AddSingleton<AuditLogColumnOptions>(auditLogColumnOptions ?? new AuditLogColumnOptions());

			services.AddSingleton<IAuditLog, SqlServerSerilogAuditLog>();

			return services;
		}
	}
}
