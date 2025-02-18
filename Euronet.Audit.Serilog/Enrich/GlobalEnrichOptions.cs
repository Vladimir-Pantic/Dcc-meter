namespace Euronet.Audit.Serilog6
{
	/// <summary>
	/// Global log parameters.
	/// </summary>
	public class GlobalEnrichOptions
	{
		/// <summary>
		/// Id of application which generated audit entry.
		/// </summary>
		public int ApplicationId { get; set; }

		/// <summary>
		/// Name of application which generated audit entry.
		/// </summary>
		public string ApplicationName { get; set; }

		/// <summary>
		/// Version of application which generated audit entry.
		/// </summary>
		public string ApplicationVersion { get; set; }
	}
}
