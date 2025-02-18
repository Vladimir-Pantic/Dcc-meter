using Euronet.Audit;
using Serilog;
using Serilog.Configuration;
using Serilog.Context;
using Serilog.Events;
using System;
using System.Web;
using System.Text.Encodings.Web;
using Euronet.Audit.Interfaces;

namespace Euronet.Audit.Serilog
{
	public abstract class SerilogAuditLog : IAuditLog
	{
		private ILogger _logger;
		private ILogger Logger
		{
			get
			{
				if (_logger == null)
				{
					_logger = CreateLogger();
				}

				return _logger;
			}
		}

		protected abstract ILogger CreateLogger();
		protected abstract bool EncodeUrl();

		~SerilogAuditLog()
		{
            if (Logger is IDisposable disposable)
            {
                disposable.Dispose();
            }
        }

		public void Log(string message, AuditLogContent opt)
		{
            if (opt is AuditLogContent options)
            {
                using (LogContext.PushProperty(AuditLogPropertyNames.ActionId, options.ActionId))
                using (LogContext.PushProperty(AuditLogPropertyNames.ActionName, options.ActionName))
                using (LogContext.PushProperty(AuditLogPropertyNames.ResourceTypeId, options.ResourceTypeId))
                using (LogContext.PushProperty(AuditLogPropertyNames.ResourceTypeName, options.ResourceTypeName))
                using (LogContext.PushProperty(AuditLogPropertyNames.ResourceId, options.ResourceId))
                using (LogContext.PushProperty(AuditLogPropertyNames.ResourceName, options.ResourceName))
                using (LogContext.PushProperty(AuditLogPropertyNames.RequestType, options.RequestType))
                using (LogContext.PushProperty(AuditLogPropertyNames.UserId, options.UserId))
                using (LogContext.PushProperty(AuditLogPropertyNames.UserName, options.UserName))
                using (LogContext.PushProperty(AuditLogPropertyNames.UserOS, options.UserOS))
                using (LogContext.PushProperty(AuditLogPropertyNames.UserOSVersion, options.UserOSVersion))
                using (LogContext.PushProperty(AuditLogPropertyNames.UserBrowser, options.UserBrowser))
                using (LogContext.PushProperty(AuditLogPropertyNames.UserBrowserVersion, options.UserBrowserVersion))
                using (LogContext.PushProperty(AuditLogPropertyNames.RequestId, options.RequestId))
                using (LogContext.PushProperty(AuditLogPropertyNames.RequestUrl, EncodeUrl() ? HttpUtility.UrlEncode(options.RequestUrl) : options.RequestUrl))
                using (LogContext.PushProperty(AuditLogPropertyNames.RequestContent, options.RequestContent))
                using (LogContext.PushProperty(AuditLogPropertyNames.RequestTimeStamp, options.RequestTimeStamp))
                using (LogContext.PushProperty(AuditLogPropertyNames.ResponseContent, options.ResponseContent))
                using (LogContext.PushProperty(AuditLogPropertyNames.ResponseTimeStamp, options.ResponseTimeStamp))
                using (LogContext.PushProperty(AuditLogPropertyNames.StatusCode, options.StatusCode))
                using (LogContext.PushProperty(AuditLogPropertyNames.Duration, options.Duration))
                {
                    Logger.Information(message);
                }
            }
            else
            {
                Logger.Information(message);
            }
        }

		public void Log(Exception exception, string message, AuditLogContent options)
		{
			if (options != null)
			{
				using (LogContext.PushProperty(AuditLogPropertyNames.ActionId, options.ActionId))
				using (LogContext.PushProperty(AuditLogPropertyNames.ActionName, options.ActionName))
				using (LogContext.PushProperty(AuditLogPropertyNames.ResourceTypeId, options.ResourceTypeId))
				using (LogContext.PushProperty(AuditLogPropertyNames.ResourceTypeName, options.ResourceTypeName))
				using (LogContext.PushProperty(AuditLogPropertyNames.ResourceId, options.ResourceId))
				using (LogContext.PushProperty(AuditLogPropertyNames.ResourceName, options.ResourceName))
				using (LogContext.PushProperty(AuditLogPropertyNames.RequestType, options.RequestType))
				using (LogContext.PushProperty(AuditLogPropertyNames.UserId, options.UserId))
				using (LogContext.PushProperty(AuditLogPropertyNames.UserName, options.UserName))
				using (LogContext.PushProperty(AuditLogPropertyNames.UserOS, options.UserOS))
				using (LogContext.PushProperty(AuditLogPropertyNames.UserOSVersion, options.UserOSVersion))
				using (LogContext.PushProperty(AuditLogPropertyNames.UserBrowser, options.UserBrowser))
				using (LogContext.PushProperty(AuditLogPropertyNames.UserBrowserVersion, options.UserBrowserVersion))
				using (LogContext.PushProperty(AuditLogPropertyNames.RequestId, options.RequestId))
				using (LogContext.PushProperty(AuditLogPropertyNames.RequestUrl, EncodeUrl() ? HttpUtility.UrlEncode(options.RequestUrl) : options.RequestUrl))
				using (LogContext.PushProperty(AuditLogPropertyNames.RequestContent, options.RequestContent))
				using (LogContext.PushProperty(AuditLogPropertyNames.RequestTimeStamp, options.RequestTimeStamp))
				using (LogContext.PushProperty(AuditLogPropertyNames.ResponseContent, options.ResponseContent))
				using (LogContext.PushProperty(AuditLogPropertyNames.ResponseTimeStamp, options.ResponseTimeStamp))
				using (LogContext.PushProperty(AuditLogPropertyNames.StatusCode, options.StatusCode))
				using (LogContext.PushProperty(AuditLogPropertyNames.Duration, options.Duration))
				{
					Logger.Error(exception, message);
				}
			}
			else
			{
				Logger.Information(exception, message);
			}
		}

		public void Log(AuditLogSeverity severity, string message, AuditLogContent options)
		{
			if (options != null)
			{
				using (LogContext.PushProperty(AuditLogPropertyNames.ActionId, options.ActionId))
				using (LogContext.PushProperty(AuditLogPropertyNames.ActionName, options.ActionName))
				using (LogContext.PushProperty(AuditLogPropertyNames.ResourceTypeId, options.ResourceTypeId))
				using (LogContext.PushProperty(AuditLogPropertyNames.ResourceTypeName, options.ResourceTypeName))
				using (LogContext.PushProperty(AuditLogPropertyNames.ResourceId, options.ResourceId))
				using (LogContext.PushProperty(AuditLogPropertyNames.ResourceName, options.ResourceName))
				using (LogContext.PushProperty(AuditLogPropertyNames.RequestType, options.RequestType))
				using (LogContext.PushProperty(AuditLogPropertyNames.UserId, options.UserId))
				using (LogContext.PushProperty(AuditLogPropertyNames.UserName, options.UserName))
				using (LogContext.PushProperty(AuditLogPropertyNames.UserOS, options.UserOS))
				using (LogContext.PushProperty(AuditLogPropertyNames.UserOSVersion, options.UserOSVersion))
				using (LogContext.PushProperty(AuditLogPropertyNames.UserBrowser, options.UserBrowser))
				using (LogContext.PushProperty(AuditLogPropertyNames.UserBrowserVersion, options.UserBrowserVersion))
				using (LogContext.PushProperty(AuditLogPropertyNames.RequestId, options.RequestId))
				using (LogContext.PushProperty(AuditLogPropertyNames.RequestUrl, EncodeUrl() ? HttpUtility.UrlEncode(options.RequestUrl) : options.RequestUrl))
				using (LogContext.PushProperty(AuditLogPropertyNames.RequestContent, options.RequestContent))
				using (LogContext.PushProperty(AuditLogPropertyNames.RequestTimeStamp, options.RequestTimeStamp))
				using (LogContext.PushProperty(AuditLogPropertyNames.ResponseContent, options.ResponseContent))
				using (LogContext.PushProperty(AuditLogPropertyNames.ResponseTimeStamp, options.ResponseTimeStamp))
				using (LogContext.PushProperty(AuditLogPropertyNames.StatusCode, options.StatusCode))
				using (LogContext.PushProperty(AuditLogPropertyNames.Duration, options.Duration))
				{
					Logger.Write((LogEventLevel)(byte)severity, message);
				}
			}
			else
			{
				Logger.Write((LogEventLevel)(byte)severity, message);
			}
		}
	}
}
