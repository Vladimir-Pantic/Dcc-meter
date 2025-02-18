using System.Linq;

namespace System.Security.Claims
{
	public static class ClaimsPrincipalExtensions
	{

		public static long GetUserId(this ClaimsPrincipal user)
		{
			if (user == null)
			{
				return 0;
			}

			long userId = 0;

			var identity = user?.Identity as ClaimsIdentity;

			var claim = identity?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

			if (claim != null)
			{
                _ = long.TryParse(claim.Value, out userId);
			}

			return userId;
		}

		public static string GetUserName(this ClaimsPrincipal user)
		{
			if (user == null)
			{
				return null;
			}

			var identity = user?.Identity as ClaimsIdentity;

			string userName = identity?.Name;

			if (string.IsNullOrWhiteSpace(userName))
			{
				userName = GetClaimValue(identity, "username");
			}

			if (string.IsNullOrWhiteSpace(userName))
			{
				userName = GetClaimValue(identity, ClaimTypes.Email);
			}

			if (string.IsNullOrWhiteSpace(userName))
			{
				userName = GetClaimValue(identity, ClaimTypes.Name);
			}

			if (string.IsNullOrWhiteSpace(userName))
			{
				userName = GetClaimValue(identity, "name");
			}

			return userName;
		}

		private static string GetClaimValue(ClaimsIdentity identity, string claimType)
		{
			var claim = identity?.Claims?.FirstOrDefault(c => c.Type == claimType);

			if (claim != null)
			{
				return claim.Value;
			}

			return null;
		}
	}
}
