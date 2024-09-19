using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Query
{
    public class PaginatedList<T> 
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }
        public List<T> Data { get; private set; }

        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            Data = items;
        }
    }

}
