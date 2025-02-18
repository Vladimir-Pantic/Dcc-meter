using Dtc.AccessSight.Mvc.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Globalization;
using System.Reflection;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Dtc.AccessSight.Mvc.ModelBinders
{
	public class QueryParamsModelBinder : IModelBinder
	{
		public Task BindModelAsync(ModelBindingContext bindingContext)
		{
			Type modelType = bindingContext.ModelType;

			object model = Activator.CreateInstance(modelType);

			HttpRequest request = bindingContext.HttpContext.Request;

			foreach (PropertyInfo property in modelType.GetProperties())
			{
				//just in case that property is read only
				if (property.CanWrite)
				{
					//only properties with data member will be binded
					DataMemberAttribute dataMember = property.GetCustomAttribute<DataMemberAttribute>();

					if (dataMember != null)
					{
						string value = QueryStringHelper.GetValue(request, dataMember.Name);

						try
						{
							if (value == null)
							{
								property.SetValue(model, null);
							}
							else
							{
								//Convert.ChangeType() fails on Nullable Types
								Type propertyType = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;

								object o = null;

								try
								{
									if (IsAmount(propertyType))
									{
										double? amount = GetAmount(value);

										if (amount != null)
										{
											o = Convert.ChangeType(amount.Value, propertyType);
										}
									}
									else
									{
										o = Convert.ChangeType(value, propertyType);
									}
								}
								//ignore parameter if conversion failed
								catch { }

								if (o != null)
								{
									property.SetValue(model, o);
								}
							}
						}
						catch (Exception ex)
						{
							bindingContext.ModelState.AddModelError(property.Name, ex.Message);
						}
					}
				}
			}

			bindingContext.Result = ModelBindingResult.Success(model);

			return Task.CompletedTask;
		}

		private double? GetAmount(string value)
		{
			if (String.IsNullOrEmpty(value))
			{
				return null;
			}

			string formatedAmount = value;

			//format input string to have only one '.' as a decimal separator, without thousend separators
			if (formatedAmount.IndexOf('.') >= 0 || formatedAmount.IndexOf(',') >= 0)
			{
				//if only ',' are present change it with '.'
				//in this case we threat resulting '.' as a decimal separator
				//and if there is more than one '.' then all numbers after first '.' appearance will be threated as decimal places.
				if (formatedAmount.IndexOf('.') < 0 && formatedAmount.IndexOf(',') >= 0)
				{
					formatedAmount = formatedAmount.Replace(',', '.');
				}
				//if both '.' and ',' are present and there is a ',' after '.'
				//then ',' is decimal separator
				else if (formatedAmount.IndexOf('.') >= 0 && formatedAmount.IndexOf(',') >= formatedAmount.IndexOf('.'))
				{
					formatedAmount = formatedAmount.Replace(".", "");
					formatedAmount = formatedAmount.Replace(",", ".");
				}
				//if both '.' and ',' are present and there is a '.' after ','
				//then '.' is decimal separator
				else if (formatedAmount.IndexOf(',') >= 0 && formatedAmount.IndexOf('.') >= formatedAmount.IndexOf(','))
				{
					formatedAmount = formatedAmount.Replace(",", "");
				}
			}

			Double result;

			Double.TryParse(formatedAmount, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out result);

			return result;
		}

		private bool IsAmount(Type propertyType)
		{
			if (propertyType == typeof(Single)
				|| propertyType == typeof(Double)
				|| propertyType == typeof(Decimal))
			{
				return true;
			}

			return false;
		}
	}
}
