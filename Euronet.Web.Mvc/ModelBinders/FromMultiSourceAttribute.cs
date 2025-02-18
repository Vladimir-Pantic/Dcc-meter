using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;

namespace Dtc.AccessSight.Web.Mvc.ModelBinders
{
	public sealed class FromMultiSourceAttribute : Attribute, IBindingSourceMetadata
	{
		public BindingSource BindingSource { get; } = CompositeBindingSource.Create(
			new[] { BindingSource.Path, BindingSource.Query },
			nameof(FromMultiSourceAttribute));
	}
}
