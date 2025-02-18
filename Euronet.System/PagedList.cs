using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Euronet.System
{
    /// <summary>
	/// List of items with paging info.
	/// </summary>
	/// <typeparam name="T">List item type.</typeparam>
	[DataContract(Name = "paged-list")]
    public class PagedList<T> : ListWithTotalCount<T>
    {
        /// <summary>
        /// Page number.
        /// </summary>
        [DataMember(Name = "page-number")]
        public int PageNumber { get; set; }

        /// <summary>
        /// Page size.
        /// </summary>
        [DataMember(Name = "page-size")]
        public int PageSize { get; set; }

        /// <summary>
        /// Number of pages.
        /// </summary>
        [DataMember(Name = "number-of-pages")]
        public int NumberOfPages { get; set; }

        public void SetPagingInfo(int totalCount, int pageSize, int pageNumber)
        {
            TotalCount = totalCount;

            PageNumber = pageNumber;

            PageSize = pageSize;

            if (PageSize == 0)
            {
                NumberOfPages = 0;
            }
            else
            {
                NumberOfPages = (TotalCount / PageSize) + ((TotalCount % PageSize > 0) ? 1 : 0);
            }
        }
    }
}
