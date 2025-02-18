using Euronet.Audit.Api.Domain.Models;
using System.Threading.Tasks;

namespace Euronet.Audit.Api.Domain.Interfaces
{
	public interface IAuditRepository
	{
		//Task<AuditLogEntryList> GetAuditLogEntryList(GetAuditLogEntryContext queryParams);

		Task<AuditLogEntry> GetAuditLogEntry(long id);

		//Task RegisterAuditLogEntry(RegisterAuditLogEntryCommand command);
	}
}
