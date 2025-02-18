using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euronet.System
{
    public class OrderBy
    {
        public string PropertyName { get; set; }

        public bool Asc { get; set; }

        public OrderBy(string propertyName, bool asc = true)
        {
            PropertyName = propertyName;
            Asc = asc;
        }
    }
}
