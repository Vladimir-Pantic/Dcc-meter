
using Serilog.Enrichers;
using Serilog.Sinks.MSSqlServer;
using System.Collections.ObjectModel;
using System.Data;

namespace Euronet.Audit.SqlServer
{
	public class AuditLogColumnOptions
	{
		public ColumnOptions GetColumnOptions()
		{
			var columnOptions = new ColumnOptions
			{
				AdditionalColumns = new Collection<SqlColumn>()
				{
					new SqlColumn()
					{
						ColumnName = AuditLogPropertyNames.ApplicationId,
						DataType = SqlDbType.Int,
						AllowNull = true
					},
					new SqlColumn()
					{
						ColumnName = EnvironmentUserNameEnricher.EnvironmentUserNamePropertyName,
						DataType = SqlDbType.VarChar,
						AllowNull = true
					},
					new SqlColumn()
					{
						ColumnName = MachineNameEnricher.MachineNamePropertyName,
						DataType = SqlDbType.VarChar,
						AllowNull = true
					}
				}
			};

			columnOptions.Store.Remove(StandardColumn.LogEvent);
			columnOptions.Store.Remove(StandardColumn.MessageTemplate);

			if (columnOptions.AdditionalColumns == null)
			{
				columnOptions.AdditionalColumns = new Collection<SqlColumn>();
			}

			columnOptions.AdditionalColumns.Add(new SqlColumn()
			{
				ColumnName = AuditLogPropertyNames.ApplicationName,
				DataType = SqlDbType.VarChar,
				AllowNull = true
			});

			columnOptions.AdditionalColumns.Add(new SqlColumn()
			{
				ColumnName = AuditLogPropertyNames.ApplicationVersion,
				DataType = SqlDbType.VarChar,
				AllowNull = true
			});

			columnOptions.AdditionalColumns.Add(new SqlColumn()
			{
				ColumnName = AuditLogPropertyNames.ActionId,
				DataType = SqlDbType.BigInt,
				AllowNull = true
			});

			columnOptions.AdditionalColumns.Add(new SqlColumn()
			{
				ColumnName = AuditLogPropertyNames.ActionName,
				DataType = SqlDbType.VarChar,
				AllowNull = true
			});

			columnOptions.AdditionalColumns.Add(new SqlColumn()
			{
				ColumnName = AuditLogPropertyNames.UserId,
				DataType = SqlDbType.BigInt,
				AllowNull = true
			});

			columnOptions.AdditionalColumns.Add(new SqlColumn()
			{
				ColumnName = AuditLogPropertyNames.UserName,
				DataType = SqlDbType.NVarChar,
				AllowNull = true
			});

			columnOptions.AdditionalColumns.Add(new SqlColumn()
			{
				ColumnName = AuditLogPropertyNames.UserOS,
				DataType = SqlDbType.VarChar,
				AllowNull = true
			});

			columnOptions.AdditionalColumns.Add(new SqlColumn()
			{
				ColumnName = AuditLogPropertyNames.UserOSVersion,
				DataType = SqlDbType.VarChar,
				AllowNull = true
			});

			columnOptions.AdditionalColumns.Add(new SqlColumn()
			{
				ColumnName = AuditLogPropertyNames.UserBrowser,
				DataType = SqlDbType.VarChar,
				AllowNull = true
			});

			columnOptions.AdditionalColumns.Add(new SqlColumn()
			{
				ColumnName = AuditLogPropertyNames.UserBrowserVersion,
				DataType = SqlDbType.VarChar,
				AllowNull = true
			});

			columnOptions.AdditionalColumns.Add(new SqlColumn()
			{
				ColumnName = AuditLogPropertyNames.ResourceTypeId,
				DataType = SqlDbType.BigInt,
				AllowNull = true
			});

			columnOptions.AdditionalColumns.Add(new SqlColumn()
			{
				ColumnName = AuditLogPropertyNames.ResourceTypeName,
				DataType = SqlDbType.VarChar,
				AllowNull = true
			});

			columnOptions.AdditionalColumns.Add(new SqlColumn()
			{
				ColumnName = AuditLogPropertyNames.ResourceId,
				DataType = SqlDbType.BigInt,
				AllowNull = true
			});

			columnOptions.AdditionalColumns.Add(new SqlColumn()
			{
				ColumnName = AuditLogPropertyNames.ResourceName,
				DataType = SqlDbType.NVarChar,
				AllowNull = true
			});

			columnOptions.AdditionalColumns.Add(new SqlColumn()
			{
				ColumnName = AuditLogPropertyNames.RequestId,
				DataType = SqlDbType.VarChar,
				AllowNull = true
			});

			columnOptions.AdditionalColumns.Add(new SqlColumn()
			{
				ColumnName = AuditLogPropertyNames.RequestUrl,
				DataType = SqlDbType.NVarChar,
				AllowNull = true
			});

			columnOptions.AdditionalColumns.Add(new SqlColumn()
			{
				ColumnName = AuditLogPropertyNames.RequestType,
				DataType = SqlDbType.VarChar,
				AllowNull = true
			});

			columnOptions.AdditionalColumns.Add(new SqlColumn()
			{
				ColumnName = AuditLogPropertyNames.RequestContent,
				DataType = SqlDbType.NVarChar,
				AllowNull = true
			});

			columnOptions.AdditionalColumns.Add(new SqlColumn()
			{
				ColumnName = AuditLogPropertyNames.RequestTimeStamp,
				DataType = SqlDbType.DateTime,
				AllowNull = true
			});

			columnOptions.AdditionalColumns.Add(new SqlColumn()
			{
				ColumnName = AuditLogPropertyNames.ResponseContent,
				DataType = SqlDbType.NVarChar,
				AllowNull = true
			});

			columnOptions.AdditionalColumns.Add(new SqlColumn()
			{
				ColumnName = AuditLogPropertyNames.ResponseTimeStamp,
				DataType = SqlDbType.DateTime,
				AllowNull = true
			});

			columnOptions.AdditionalColumns.Add(new SqlColumn()
			{
				ColumnName = AuditLogPropertyNames.StatusCode,
				DataType = SqlDbType.Int,
				AllowNull = true
			});

			columnOptions.Properties.ExcludeAdditionalProperties = true;

			columnOptions.Level.StoreAsEnum = true;

			return columnOptions;
		}
	}
}
