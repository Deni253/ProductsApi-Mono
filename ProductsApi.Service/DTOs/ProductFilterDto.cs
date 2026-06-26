using ProductsApi.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApi.Service.DTOs
{
    public class ProductFilterDto
    {
          public Guid CategoryId { get; set; }

          public int PriceMin { get; set; }
          public int PriceMax { get; set; }
          public bool IsActive { get; set; }
    }
}
