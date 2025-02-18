using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DccMeter.Api.Domain.Models
{
    /// <summary>
	/// Enumeration for User sorting options.
	/// </summary>
	[Serializable]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum UserSortingOption
    {
        /// <summary>
        /// Id
        /// </summary>
        [EnumMember(Value = "idx")]
        Idx = 0,

        /// <summary>
        /// Name
        /// </summary>
        [EnumMember(Value = "user-name")]
        UserName = 1,
    }
}
