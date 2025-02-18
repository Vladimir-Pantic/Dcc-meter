using System.Runtime.Serialization;

namespace Dtc.AccessSight.Mvc.QueryParams
{
	[DataContract(Name = "paging-query-params")]
	//[ModelBinder(BinderType = typeof(QueryParamsModelBinder))]
	public class PagingQueryParams
	{
		[DataMember(Name = "page-size")]
		public int PageSize { get; set; }

		[DataMember(Name = "page-number")]
		public int PageNumber { get; set; }
	}
}
