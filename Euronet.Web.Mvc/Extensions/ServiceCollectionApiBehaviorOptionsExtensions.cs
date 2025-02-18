
using Euronet.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
	public static class ServiceCollectionApiBehaviorOptionsExtensions
	{ 
		public static IServiceCollection ConfigureApiProblemResponseFactory(this IServiceCollection services)
		{
			services.Configure<ApiBehaviorOptions>(options =>
			{
				options.InvalidModelStateResponseFactory = actionContext =>
				{
					return actionContext.GetApiProblemResult();
				};
			});

			return services;
		}
	}
}
