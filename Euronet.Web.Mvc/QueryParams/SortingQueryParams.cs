using System.Runtime.Serialization;

namespace Dtc.AccessSight.Mvc.QueryParams
{
	[DataContract(Name = "sorting-query-params")]
	//[ModelBinder(BinderType = typeof(QueryParamsModelBinder))]
	public class SortingQueryParams
	{
		[DataMember(Name = "sort-name")]
		public string SortName { get; set; }

		[DataMember(Name = "sort-direction")]
		public string SortDirection { get; set; }
	}
}
