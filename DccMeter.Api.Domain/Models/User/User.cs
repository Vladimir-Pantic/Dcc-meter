using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DccMeter.Api.Domain.Models
{
    [DataContract(Name ="user")]
    public class User
    {
        [DataMember(Name ="idx")]
        public int Idx { get; set; }

        [DataMember(Name ="eid")]
        public int Eid { get; set; }

        [DataMember(Name = "user-name")]
        public string UserName { get; set; } = string.Empty;

        [DataMember(Name = "user-email")]
        public string UserEmail { get; set; } = string.Empty;

        [DataMember(Name = "user-team-id")]
        public int? UserTeamId { get; set; }
    }
}
