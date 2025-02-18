using System;
using System.Collections.Generic;
using System.Text;

namespace Euronet.Audit
{
	public static class RequestHelper
	{
		public static string FormatRequestUrl(string requestUrl)
		{
			return requestUrl.Replace("%3A", ":");
		}
	}
}
