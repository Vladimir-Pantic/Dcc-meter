
using Euronet.Audit;
using Euronet.Audit.Serilog;

namespace Serilog
{
	public static class LoggerConfigurationExtensions
	{
		public static LoggerConfiguration Enrich(this LoggerConfiguration loggerConfiguration, GlobalEnrichOptions options)
		{
			if (options != null)
			{
				loggerConfiguration.Enrich.WithProperty(AuditLogPropertyNames.ApplicationId, options.ApplicationId);
				loggerConfiguration.Enrich.WithProperty(AuditLogPropertyNames.ApplicationName, options.ApplicationName);
				loggerConfiguration.Enrich.WithProperty(AuditLogPropertyNames.ApplicationVersion, options.ApplicationVersion);
			}

			loggerConfiguration.Enrich.WithMachineName();

			loggerConfiguration.Enrich.WithEnvironmentUserName();

			return loggerConfiguration;
		}
	}
}
