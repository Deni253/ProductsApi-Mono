using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApi.Service.DTOs
{
    public class CategorySortDTO
    {
        public enum Sort { Ascending,Descending }
        public Sort SortBy { get; set; }
    }
}
