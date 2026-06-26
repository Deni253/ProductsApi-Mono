using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApi.Service.DTOs
{
    public class PagingDto
    {
        public int ItemsPerPage { get; set; }
        public int PageNumber { get; set; }


    }
}
