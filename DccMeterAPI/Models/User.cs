using System.Runtime.Serialization;

namespace DccMeterAPI.Models
{
    [DataContract]
    public class User
    {
        /// <summary>
        /// Idx
        /// </summary>
        [DataMember(Name = "idx")]
        public int Idx { get; set; }

        public int? Eid { get; set; }

        public string? UserName { get; set; }

        public string? UserEmail { get; set; }

        public int? UserTeamId { get; set; }    
    }
}
