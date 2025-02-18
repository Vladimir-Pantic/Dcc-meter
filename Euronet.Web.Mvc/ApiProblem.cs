﻿
using Euronet.Exceptions;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Euronet.Web
{
    /// <summary>
    /// A machine-readable format for specifying errors in HTTP API responses based on https://tools.ietf.org/html/rfc7807.
    /// </summary>
    public class ApiProblem
    {
        public ApiProblem()
        {
        }

        public ApiProblem(int code)
        {
            Errors.Add(new ErrorDetails(code));
        }

        public ApiProblem(string message)
        {
            Errors.Add(new ErrorDetails(message));
        }

        public ApiProblem(string message, int code)
        {
            Errors.Add(new ErrorDetails(message, code));
        }

        /// <summary>
        /// A URI reference [RFC3986] that identifies the problem type. This specification encourages that, when
        /// dereferenced, it provide human-readable documentation for the problem type
        /// (e.g., using HTML [W3C.REC-html5-20141028]).  When this member is not present, its value is assumed to be
        /// "about:blank".
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// A short, human-readable summary of the problem type.It SHOULD NOT change from occurrence to occurrence
        /// of the problem, except for purposes of localization(e.g., using proactive content negotiation;
        /// see[RFC7231], Section 3.4).
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        /// The HTTP status code([RFC7231], Section 6) generated by the origin server for this occurrence of the problem.
        /// </summary>
        [JsonPropertyName("status")]
        public int? Status { get; set; }

        /// <summary>
        /// A human-readable explanation specific to this occurrence of the problem.
        /// </summary>
        [JsonPropertyName("detail")]
        public string Detail { get; set; }

        /// <summary>
        /// A URI reference that identifies the specific occurrence of the problem.It may or may not yield further information if dereferenced.
        /// </summary>
        [JsonPropertyName("instance")]
        public string Instance { get; set; }

        private List<ErrorDetails> _Errors;
        /// <summary>
        /// List of errors details.
        /// </summary>
        [JsonPropertyName("errors")]
        public List<ErrorDetails> Errors
        {
            get
            {
                if (_Errors == null)
                {
                    _Errors = new List<ErrorDetails>();
                }

                return _Errors;
            }
        }
    }
}