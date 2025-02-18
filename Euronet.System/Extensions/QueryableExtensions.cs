using Euronet.System;
using Euronet.System.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace System.Linq
{
    public static class QueryableExtensions
    {
        public static IQueryable<TSource> OrderBy<TSource>(this IQueryable<TSource> query, List<OrderBy> orderByList)
        {
            if (query == null)
            {
                return null;
            }

            if (orderByList == null)
            {
                return query;
            }

            foreach (OrderBy _orderBy in orderByList)
            {
                query = query.OrderBy(_orderBy);
            }

            return query;
        }

        public static IQueryable<TSource> OrderBy<TSource>(this IQueryable<TSource> query, OrderBy orderBy)
        {
            if (query == null)
            {
                return null;
            }

            if (orderBy == null)
            {
                return query;
            }

            return query.OrderBy(orderBy.PropertyName, orderBy.Asc);
        }

        public static IQueryable<TSource> OrderBy<TSource>(this IQueryable<TSource> query, string propertyName, string sortDirection)
        {
            if (query == null)
            {
                return null;
            }

            if (string.IsNullOrEmpty(propertyName))
            {
                return query;
            }

            bool asc = true;
            if (sortDirection != null && (sortDirection.ToLower().StartsWith("desc") || sortDirection.ToLower().StartsWith("dsc")))
            {
                asc = false;
            }

            return query.OrderBy(propertyName, asc);
        }

        public static IOrderedQueryable<TSource> OrderByDescending<TSource>(this IQueryable<TSource> query, string propertyName)
        {
            return query.OrderBy(propertyName, asc: false);
        }

        public static IOrderedQueryable<TSource> OrderBy<TSource>(this IQueryable<TSource> query, string propertyName, bool asc = true)
        {
            if (query == null)
            {
                return null;
            }

            if (string.IsNullOrEmpty(propertyName))
            {
                throw new ArgumentNullException("propertyName");
            }

            Type typeFromHandle = typeof(TSource);
            string name = (asc ? "OrderBy" : "OrderByDescending");
            PropertyInfo property = typeFromHandle.GetProperty(propertyName);
            ParameterExpression parameterExpression = Expression.Parameter(typeFromHandle, "x");
            MemberExpression body = Expression.Property(parameterExpression, propertyName);
            LambdaExpression lambdaExpression = Expression.Lambda(body, parameterExpression);
            Type typeFromHandle2 = typeof(Queryable);
            MethodInfo methodInfo = (from m in typeFromHandle2.GetMethods()
                                     where m.Name == name && m.IsGenericMethodDefinition
                                     select m).Where(delegate (MethodInfo m)
                                     {
                                         List<ParameterInfo> list = m.GetParameters().ToList();
                                         return list.Count == 2;
                                     }).Single();
            MethodInfo methodInfo2 = methodInfo.MakeGenericMethod(typeFromHandle, property.PropertyType);
            return (IOrderedQueryable<TSource>)methodInfo2.Invoke(methodInfo2, new object[2] { query, lambdaExpression });
        }

        public static IQueryable<TSource> TakePage<TSource>(this IQueryable<TSource> query, int pageNumber, int pageSize)
        {
            if (query == null)
            {
                return null;
            }

            if (pageNumber <= 0)
            {
                pageNumber = 1;
            }

            if (pageSize <= 0)
            {
                pageSize = 10;
            }

            return query.Skip(pageSize * (pageNumber - 1)).Take(pageSize);
        }

        public static IQueryable<T> ApplySorting<T>(this IQueryable<T> query, string sortName, SortDirection? sortDirection)
        {
            if (query != null && !sortName.IsNullOrEmpty())
            {
                bool asc = true;
                if (!sortDirection.HasValue || sortDirection == SortDirection.Dsc)
                {
                    asc = false;
                }

                return query.OrderBy(sortName, asc);
            }

            return query;
        }

        public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> query, ref int? pageSize, ref int? pageNumber)
        {
            if (query != null)
            {
                int num = 20;
                if (pageSize.HasValue && pageSize <= 100)
                {
                    num = pageSize.Value;
                }
                else
                {
                    pageSize = 20;
                }

                int count = 0;
                if (pageNumber.HasValue && pageNumber > 0)
                {
                    count = (pageNumber.Value - 1) * num;
                }
                else
                {
                    pageNumber = 1;
                }

                query = query.Skip(count);
                query = query.Take(num);
            }

            return query;
        }
    }
}