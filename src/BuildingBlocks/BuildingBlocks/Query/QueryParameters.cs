using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Requests
{
    public class QueryParameters
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        //public string SortBy { get; set; } = "Id";
        //public bool IsSortDescending { get; set; } = false;
        //public bool? Descending { get; set; }
        //public List<FilterCondition> FilterConditions { get; set; } = new List<FilterCondition>();
        //public bool UseOrOperator { get; set; } = false; // AND (default) or OR logic
    }
}
