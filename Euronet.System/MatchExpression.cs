﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Euronet.System
{
    public class MatchExpression
    {
        public List<Regex> Regexes { get; set; }

        public Action<Match, object> Action { get; set; }
    }
}
