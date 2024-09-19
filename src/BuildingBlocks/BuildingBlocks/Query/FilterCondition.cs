using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Requests
{
    public class FilterCondition
    {
        public string PropertyName { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public string Operator { get; set; } = "Equals"; // Could be Equals, Contains, etc.
    }
}
