using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Euronet.System
{
    [DataContract(Name ="list-with-total-count")]
    public class ListWithTotalCount<T>
    {
        /// <summary>
        /// Items.
        /// </summary>
        [DataMember(Name = "items")]
        public IEnumerable<T> Items { get; set; }

        /// <summary>
        /// Total count of items.
        /// </summary>
        [DataMember(Name = "total-count")]
        public int TotalCount { get; set; }
    }
}
