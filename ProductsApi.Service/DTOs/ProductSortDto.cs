using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApi.Service.DTOs
{
    public class ProductSortDto
    {
        public enum SortBy { Price, Name, Date }
        public enum SortDirection { Ascending, Descending }

        public SortBy Sort { get; set; }
        public SortDirection Direction { get; set; }
    }
}
