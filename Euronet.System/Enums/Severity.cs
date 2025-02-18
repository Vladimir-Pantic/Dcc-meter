using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json.Converters;

namespace System.Collections.Generic
{
    [Serializable]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Severity
    {
        [EnumMember(Value = "info")]
        [Display(Name = "Info")]
        Info = 0,

        [EnumMember(Value = "warning")]
        [Display(Name = "Warning")]
        Warning = 1,

        [EnumMember(Value = "error")]
        [Display(Name = "Error")]
        Error = 2
    }
}
