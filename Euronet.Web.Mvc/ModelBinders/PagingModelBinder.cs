using Dtc.AccessSight.Mvc.Helpers;
using Dtc.AccessSight.Mvc.QueryParams;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;

namespace Dtc.AccessSight.Mvc.ModelBinders
{
	public class PagingModelBinder : IModelBinder
	{
		public Task BindModelAsync(ModelBindingContext bindingContext)
		{
			PagingQueryParams pagingQueryParams = new PagingQueryParams();

			pagingQueryParams.PageSize = QueryStringHelper.GetValue(bindingContext.HttpContext.Request, "page-size", 10);

			pagingQueryParams.PageNumber = QueryStringHelper.GetValue(bindingContext.HttpContext.Request, "page-number", 1);

			bindingContext.Result = ModelBindingResult.Success(pagingQueryParams);

			return Task.CompletedTask;
		}
	}
}
