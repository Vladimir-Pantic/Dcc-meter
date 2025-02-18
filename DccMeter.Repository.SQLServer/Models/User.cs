using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DccMeter.Repository.SQLServer.Models
{
    [Table("cfg_user", Schema ="dbo")]
    public class User
    {
        [Key]
        public int Idx { get; set; }

        public int Eid { get; set; }

        public string UserName { get; set; } = string.Empty;

        public string UserEmail { get; set; } = string.Empty;

        public int? UserTeamId { get; set; }
    }
}
