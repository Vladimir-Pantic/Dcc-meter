using Microsoft.AspNetCore.Http;

namespace Dtc.AccessSight.Audit.Api.Domain
{
	public enum ErrorCodes
	{
		#region Basic

		/// <summary>
		/// Bad request.
		/// </summary>
		BadRequest = StatusCodes.Status400BadRequest,

		/// <summary>
		/// Unauthorized.
		/// </summary>
		Unauthorized = StatusCodes.Status401Unauthorized,

		/// <summary>
		/// Forbidden.
		/// </summary>
		Forbidden = StatusCodes.Status403Forbidden,

		/// <summary>
		/// Not found.
		/// </summary>
		NotFound = StatusCodes.Status404NotFound,

		/// <summary>
		/// Conflict.
		/// </summary>
		Conflict = StatusCodes.Status409Conflict,

		/// <summary>
		/// Internal server error.
		/// </summary>
		InternalServerError = StatusCodes.Status500InternalServerError,

		#endregion

		#region Audit 10001-11000

		RegisterAuditLogEntryFailed = 10001,

		AuditLogEntryNotFound = 10002,

		#endregion

	}
}
