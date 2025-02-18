using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DccMeter.Api.Domain.Models
{
    [DataContract(Name ="modify-user-command")]
    public class ModifyUserCommand
    {

        [DataMember(Name = "eid")]
        public int Eid { get; set; }

        [DataMember(Name = "user-name")]
        public string UserName { get; set; }

        [DataMember(Name = "user-email")]
        public string UserEmail { get; set; }

        [DataMember(Name = "user-team-id")]
        public int? UserTeamId { get; set; }
    }
}
