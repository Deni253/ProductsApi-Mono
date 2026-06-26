using ProductsApi.Service.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApi.Service.DTOs
{
    public class CreateProductDTO
    {
        [Required]
        public Guid CategoryId { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [Range(0.01, double.MaxValue)]
        public double Price { get; set; }

        [Range(0, 500)]
        public int StockQuantity { get; set; }     
    }
}
