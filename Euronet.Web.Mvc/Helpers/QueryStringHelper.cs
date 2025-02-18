using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;

namespace Dtc.AccessSight.Mvc.Helpers
{
	public static class QueryStringHelper
	{
		public static int GetValue(HttpRequest request, string key, int defaultValue)
		{
			int result = defaultValue;

			if (request != null)
			{
				string value = GetValue(request, key);

				if (!String.IsNullOrEmpty(value))
				{
					int.TryParse(value, out result);
				}
			}

			return result;
		}

		public static int? GetValue(HttpRequest request, string key, int? defaultValue)
		{
			int? result = defaultValue;

			if (request != null)
			{
				string value = GetValue(request, key);

				if (!String.IsNullOrEmpty(value))
				{
					int r;

					if (int.TryParse(value, out r))
					{
						result = r;
					}
				}
			}

			return result;
		}

		public static string GetValue(HttpRequest request, string key, string defaultValue)
		{
			string result = defaultValue;

			if (request != null)
			{
				result = GetValue(request, key);
			}

			return result;
		}

		public static string GetValue(HttpRequest request, string key)
		{
			QueryString queryString = request.QueryString;

			if (queryString != null && queryString.Value != null)
			{
				Dictionary<string, StringValues> dict = QueryHelpers.ParseQuery(queryString.Value);

				if (dict != null)
				{
					if (dict.ContainsKey(key))
					{
						StringValues values = dict[key];

						if (values.Count > 0)
						{
							return values[0];
						}
					}
				}
			}

			return null;
		}

		public static StringValues GetValues(Microsoft.AspNetCore.Http.HttpRequest request, string key)
		{
			Microsoft.AspNetCore.Http.QueryString queryString = request.QueryString;

			if (queryString != null && queryString.Value != null)
			{
				Dictionary<string, Microsoft.Extensions.Primitives.StringValues> dict = QueryHelpers.ParseQuery(queryString.Value);

				if (dict != null)
				{
					if (dict.ContainsKey(key))
					{
						return dict[key];
					}
				}
			}

			return new StringValues();
		}
	}
}
