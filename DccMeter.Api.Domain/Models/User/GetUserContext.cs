using Euronet.System.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DccMeter.Api.Domain.Models
{
    [DataContract(Name ="get-user-context")]
    public class GetUserContext
    {
        [FromQuery(Name ="idx")]
        public int? Idx { get; set; }

        [FromQuery(Name ="eid")]
        public int? Eid { get; set; }

        [FromQuery(Name ="user-name")]
        public string? UserName { get; set; }

        [FromQuery(Name ="user-email")]
        public string? UserEmail { get; set; }

        [FromQuery(Name ="user-team-id")]
        public int? UserTeamId { get; set; }

        /// <summary>
		/// Page size
		/// </summary>
        [FromQuery(Name = "page-size")]
        public int? PageSize { get; set; }

        /// <summary>
        /// Page number
        /// </summary>
        [FromQuery(Name = "page-number")]
        public int? PageNumber { get; set; }

        /// <summary>
        /// Sort by option.
        /// </summary>
        [FromQuery(Name = "sort-by")]
        public UserSortingOption? SortBy { get; set; }

        /// <summary>
        /// SortDirection
        /// </summary>
        [FromQuery(Name = "sort-direction")]
        public SortDirection? SortDirection { get; set; }

        /// <summary>
        /// List of include options.
        /// </summary>
        //[FromQuery(Name = "includes")]
        //public UserShapingOption[] Includes { get; set; }

    }
}
